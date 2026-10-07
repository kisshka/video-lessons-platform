using EducationContentService.Core;
using EducationContentService.Core.Features.Lessons;
using EducationContentService.Web.EndpointSettings;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Exceptions;

namespace EducationContentService.Web.Configuration
{
    internal static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddConfiguration (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<CreateHandler>();

            return services
                .AddSerilogLogging(configuration)
                .AddOpenApiSpec()
                .AddEndpoints(typeof(IEndpoint).Assembly);
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


        private static IServiceCollection AddSerilogLogging(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSerilog((services, lc) => lc
                .ReadFrom.Configuration(configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithProperty("ServiceName", "LessonService" )
                );
            return services;
        }
    }
}
