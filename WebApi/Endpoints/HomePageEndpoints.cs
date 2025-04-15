using AeC.AutomationChallenge.Application.HomePage.Commands.RecordSearchData;
using AeC.AutomationChallenge.WebApi.Extensions;
using MediatR;

namespace AeC.AutomationChallenge.WebApi.Endpoints
{
    public static class HomePageEndpoints
    {
        public static void MapHomePageEndpoints(this WebApplication app)
        {
            var group = app
                .MapGroup("RecordHomePageSearchData")
                .WithTags("homePage")
                .WithOpenApi();

            group
                .MapPost("/", async (ISender sender, RecordHomePageSearchDataCommand command, CancellationToken ct)
                => await sender.Send(command, ct))
                .WithName("RecordHomePageSearchData")
                .ProducesPost();
        }
    }
}