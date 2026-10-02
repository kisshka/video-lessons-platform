using EducationContentService.Core.EndpointSettings;
using Serilog;

namespace EducationContentService.Core.Configuration
{
    public static class AppExtensions
    {
        public static IApplicationBuilder ConfigureApp(this WebApplication app)
        {       
            app.UseSerilogRequestLogging();

            app.UseSwagger();
            app.UseSwaggerUI();

            var apiGroup = app.MapGroup("/api/lessons").WithOpenApi();

            app.MapEndpoints(apiGroup);

            return app;
        }
    }
}
