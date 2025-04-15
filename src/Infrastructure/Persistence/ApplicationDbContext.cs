using AeC.AutomationChallenge.Domain.HomePage.Dtos;
using AeC.AutomationChallenge.Infrastructure.Interfaces;
using AeC.AutomationChallenge.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace AeC.AutomationChallenge.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly EntitySaveChangesInterceptor _saveChangesInterceptor;

        public DbSet<HomePageSearchDataDto> HomePageSearchData { get; set; } = default!;

        public ApplicationDbContext(DbContextOptions options, EntitySaveChangesInterceptor saveChangesInterceptor) : base(options)
        {
            _saveChangesInterceptor = saveChangesInterceptor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(
                _saveChangesInterceptor);
        }
    }
}