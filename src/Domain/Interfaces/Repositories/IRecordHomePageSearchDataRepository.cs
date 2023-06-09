using AeC.AutomationChallenge.Domain.HomePage.Dtos;

namespace AeC.AutomationChallenge.Domain.Interfaces.Repositories
{
    public interface IRecordHomePageSearchDataRepository
    {
        Task<Guid> RecordHomePageSearchData(HomePageSearchDataDto dto, CancellationToken cancellationToken);
    }
}
