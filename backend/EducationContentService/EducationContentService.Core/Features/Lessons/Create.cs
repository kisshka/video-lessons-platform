using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace EducationContentService.Core.Features.Lessons
{
    public sealed class CreateEndpoint : IEndpoint
    {

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("api/lessons", async (CreateHandler handler) =>
            {
                await handler.Handle();
            });
        }
    }

    public sealed class CreateHandler
    {
        private readonly ILogger<CreateHandler> _logger;

        public CreateHandler(ILogger<CreateHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
}