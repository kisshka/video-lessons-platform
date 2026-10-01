using EducationContentService.Core.EndpointSettings;

namespace EducationContentService.Core.Configuration
{
    public static class AppExtensions
    {
        public static IApplicationBuilder ConfigureApp(this WebApplication app)
        {

                app.UseSwagger();
                app.UseSwaggerUI();

            var apiGroup = app.MapGroup("/api/lessons").WithOpenApi();

            app.MapEndpoints(apiGroup);

            return app;
        }
    }
}
