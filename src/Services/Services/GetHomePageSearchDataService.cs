using AeC.AutomationChallenge.Domain.HomePage.Transport;
using AeC.AutomationChallenge.Domain.Interfaces.Services;

namespace AeC.AutomationChallenge.Services.HomePageSearchData
{
    public class GetHomePageSearchDataService : IGetHomePageSearchDataService
    {
        public async Task<HomePageSearchDataResponse> GetHomePageSearchData(string searchTerm, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new HomePageSearchDataResponse());
        }
    }
}
