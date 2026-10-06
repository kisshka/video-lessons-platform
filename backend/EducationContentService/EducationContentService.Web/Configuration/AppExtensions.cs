using EducationContentService.Web.EndpointSettings;
using Serilog;

namespace EducationContentService.Web.Configuration
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
