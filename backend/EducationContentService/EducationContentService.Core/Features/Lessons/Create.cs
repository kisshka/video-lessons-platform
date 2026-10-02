using EducationContentService.Core.EndpointSettings;

namespace EducationContentService.Core.Features.Lessons
{
    internal sealed class CreateEndpoint : IEndpoint
    {

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("api/lessons", async (CreateHandler handler) =>
            {
                await handler.Handle();
            });
        }
    }

    internal sealed class CreateHandler
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