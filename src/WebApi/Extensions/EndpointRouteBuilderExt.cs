namespace AeC.AutomationChallenge.WebApi.Extensions
{
    public static class EndpointRouteBuilderExt
    {
        public static RouteHandlerBuilder ProducesPost(this RouteHandlerBuilder builder)
            =>
            builder
            .Produces(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}