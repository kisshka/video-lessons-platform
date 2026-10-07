using EducationContentService.Web.EndpointSettings;
using EducationContentService.Web.Middlewares;
using Serilog;

namespace EducationContentService.Web.Configuration
{
    public static class AppExtensions
    {
        public static IApplicationBuilder Configure(this WebApplication app)
        {
            app.UseRequestCorellationId();
            app.UseSerilogRequestLogging();

            app.UseSwagger();
            app.UseSwaggerUI();

            var apiGroup = app.MapGroup("/api/lessons").WithOpenApi();

            app.MapEndpoints(apiGroup);

            return app;
        }
    }
}
