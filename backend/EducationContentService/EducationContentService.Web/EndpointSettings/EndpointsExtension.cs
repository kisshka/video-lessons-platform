using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualBasic;
using System.Reflection;

namespace EducationContentService.Web.EndpointSettings
{
    internal static class EndpointsExtension
    {
        // Добавление Эндпоинтов в DI контейнер
        public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
        {
            IEnumerable<ServiceDescriptor> servicesDescriptors = assembly
                .DefinedTypes
                .Where(type => type is { IsAbstract: false, IsInterface: false } && type.IsAssignableTo(typeof(IEndpoint)))
                .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type));

            services.TryAddEnumerable(servicesDescriptors);

            return services;
        }

        // Добавление Эндпоинтов в маршруты приложения
        public static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
        {
            var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

            IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

            foreach (var endpoint in endpoints)
            {
                endpoint.MapEndpoint(builder);
            }

            return app;
        }
    }
}
