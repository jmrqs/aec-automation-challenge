using AeC.AutomationChallenge.Domain.HomePage.Dtos;

namespace AeC.AutomationChallenge.Domain.Interfaces.Repositories
{
    public interface IRecordHomePageSearchDataRepository
    {
        Task<HomePageSearchDataDto> RecordHomePageSearchData(HomePageSearchDataDto dto, CancellationToken cancellationToken);
    }
}
