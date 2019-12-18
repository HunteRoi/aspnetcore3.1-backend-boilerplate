using System;
using API.Extensions;
using API.Infrastructure;
using AutoMapper;
using DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models.V1;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddScoped<PersonRepository>()
                .AddSingleton<IMapper>(_ => ModelMapperFactory.CreateMapperV1())
                .AddVersioning()
                .AddContext(Configuration.GetConnectionString("DbContext"))
                .AddSwaggerDocumentation()
                .AddSecurity(Configuration[AuthenticationConfigurationKeys.AUTHORITY], Configuration[AuthenticationConfigurationKeys.AUDIENCE])
                .AddControllers(options => options.Filters.Add(new CustomExceptionFilter()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseSwaggerDocumentation(provider)
                .UseSecurity()
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}