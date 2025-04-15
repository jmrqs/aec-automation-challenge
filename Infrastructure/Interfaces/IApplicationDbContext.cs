using AeC.AutomationChallenge.Domain.HomePage.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AeC.AutomationChallenge.Infrastructure.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<HomePageSearchDataDto> HomePageSearchData { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
