using AeC.AutomationChallenge.Domain.HomePage.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AeC.AutomationChallenge.Infrastructure.Persistence.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<HomePageSearchDataDto>
    {
        public void Configure(EntityTypeBuilder<HomePageSearchDataDto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Area);

            builder.Property(c => c.Author);

            builder.Property(c => c.Description);

            builder.Property(c => c.PublishingDate);
        }
    }
}
