using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSecurity(this IApplicationBuilder app)
        {
            return app
                .UseHttpsRedirection()
                .UseAuthorization()
                .UseAuthentication()
                .UseCors();
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            return app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.RoutePrefix = string.Empty;
                    options.DocumentTitle = "RESTful API Docs";
                    options.DefaultModelExpandDepth(2);
                    options.DefaultModelRendering(ModelRendering.Example);
                    //options.DefaultModelsExpandDepth(-1); // hide the schemas from the Swagger UI
                    options.EnableDeepLinking();
                    options.ShowExtensions();
                    options.DisplayRequestDuration();
                    options.DocExpansion(DocExpansion.List);

                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
        }
    }
}
