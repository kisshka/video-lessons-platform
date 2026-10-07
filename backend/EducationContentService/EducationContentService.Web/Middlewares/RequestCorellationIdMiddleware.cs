using Serilog.Context;

namespace EducationContentService.Web.Middlewares
{
    public class RequestCorellationIdMiddleware
    {
        private const string CORRELATION_ID_HEADER_NAME = "X-Corellation-Id";
        private const string CORRELATION_ID = "CorrelationId";
        private readonly RequestDelegate _next; 
        public RequestCorellationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Request.Headers.TryGetValue(CORRELATION_ID_HEADER_NAME, out var correlationIdValues);

            var corellationId = correlationIdValues.FirstOrDefault() ?? context.TraceIdentifier;

            using (LogContext.PushProperty(CORRELATION_ID, corellationId))
            {
                return _next(context);
            }
        }

    }

    public static class RequestCorellationIdMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestCorellationId (this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestCorellationIdMiddleware>();
        }
    }
}
