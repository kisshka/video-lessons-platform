using Microsoft.AspNetCore.Routing;

namespace EducationContentService.Core
{
    public interface IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app);
    }

}
