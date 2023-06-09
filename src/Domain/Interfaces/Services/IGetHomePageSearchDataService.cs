using AeC.AutomationChallenge.Domain.HomePage.Dtos;
using AeC.AutomationChallenge.Domain.HomePage.Transport;

namespace AeC.AutomationChallenge.Domain.Interfaces.Services
{
    public interface IGetHomePageSearchDataService
    {
        Task<HomePageSearchDataResponse> GetHomePageSearchData(string searchTerm, CancellationToken cancellationToken);
    }
}
