using System;
using API.Infrastructure;
using DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services, string authority, string audience)
        {
            services
                .AddCors(options =>
                {
                    options.AddDefaultPolicy(b => b
                        .AllowAnyOrigin() // !! NOT SAFE !! Please consider using .WithOrigins("...") and other more constraining methods
                        .AllowAnyMethod()
                        .AllowAnyHeader());
                })
                .AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>()
                .AddSingleton<IAuthorizationHandler, HasScopeHandler>()
                .AddAuthorization()
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = authority;
                    options.Audience = audience;
                });
            return services;
        }

        public static IServiceCollection AddContext(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            return services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            return services
                .AddApiVersioning(options =>
                {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                })
                .AddVersionedApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VV";
                    options.SubstituteApiVersionInUrl = true;
                });
        }

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            return services
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
                .AddSwaggerGen(options =>
                {
                    options.OperationFilter<SwaggerDefaultValues>();
                });
        }
    }
}