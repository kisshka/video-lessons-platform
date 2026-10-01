using EducationContentService.Core.EndpointSettings;
using Microsoft.OpenApi.Models;

namespace EducationContentService.Core.Configuration
{
    internal static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddConfiguration (this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddOpenApiSpec()
                .AddEndpoints(typeof(Program).Assembly);
        }

        private static IServiceCollection AddOpenApiSpec(this IServiceCollection services)
        {
            services.AddOpenApi();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Education Content Service",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Tashka",
                        Email = "taha@gmail.com"
                    }
                });
            });

            return services;
        }
    }
}
