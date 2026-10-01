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
        public async Task Handle()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
}