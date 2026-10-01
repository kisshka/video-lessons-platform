using EducationContentService.Core.Configuration;
using EducationContentService.Core.EndpointSettings;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfiguration(builder.Configuration);

var app = builder.Build();

app.ConfigureApp();

app.Run();