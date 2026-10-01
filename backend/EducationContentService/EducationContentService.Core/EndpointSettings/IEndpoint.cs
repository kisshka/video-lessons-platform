namespace EducationContentService.Core.EndpointSettings
{
    internal interface IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app);
    }

}
