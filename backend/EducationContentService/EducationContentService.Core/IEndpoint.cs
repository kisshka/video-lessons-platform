using Microsoft.AspNetCore.Routing;

namespace EducationContentService.Core
{
    internal interface IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app);
    }

}
