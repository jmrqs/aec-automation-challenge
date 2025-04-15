using AeC.AutomationChallenge.Domain.HomePage.Dtos;
using AeC.AutomationChallenge.Domain.Interfaces.Repositories;
using AeC.AutomationChallenge.Infrastructure.Interfaces;

namespace AeC.AutomationChallenge.Infrastructure.Repositories
{
    public class RecordHomePageSearchDataRepository : IRecordHomePageSearchDataRepository
    {
        private readonly IApplicationDbContext _dbContext;
        public RecordHomePageSearchDataRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HomePageSearchDataDto> RecordHomePageSearchData(HomePageSearchDataDto dto, CancellationToken cancellationToken)
        {
            _dbContext.HomePageSearchData.Add(dto);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return dto;
        }
    }
}