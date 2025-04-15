using AeC.AutomationChallenge.Domain.HomePage.Transport;

namespace AeC.AutomationChallenge.Domain.Interfaces.Services
{
    public interface IGetHomePageSearchDataService
    {
        Task<SaveTheHomePageResultInDatabaseResponse> GetHomePageSearchData(string searchTerm, CancellationToken cancellationToken);
    }
}
