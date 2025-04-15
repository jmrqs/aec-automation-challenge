namespace AeC.AutomationChallengeApplication.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<HomePageSearchData> HomePageSearchData { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}