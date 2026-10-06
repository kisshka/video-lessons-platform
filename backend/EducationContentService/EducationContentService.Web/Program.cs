using Serilog;
using EducationContentService.Core.EndpointSettings;
using Microsoft.OpenApi.Models;
using System.Globalization;
using EducationContentService.Web.Configuration;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting up");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddConfiguration(builder.Configuration);

    var app = builder.Build();

    app.ConfigureApp();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}
