using AeC.AutomationChallenge.Domain.Common.Base.AeC.AutomationChallenge.Domain.Common.Base;

namespace AeC.AutomationChallenge.Domain.HomePage.Dtos
{
    public class HomePageSearchDataDto : AggregateRoot<Guid>
    {
        public string Title { get; private set; } = null!;

        public string Area { get; private set; } = null!;

        public string Author { get; private set; } = null!;

        public string Description { get; private set; } = null!;

        public DateTime PublishingDate { get; set; } = DateTime.MinValue!;

        private HomePageSearchDataDto() { }

        public static HomePageSearchDataDto Create(HomePageSearchDataDto dto)
        {
            Guard.Against.Empty(dto.Title);
            Guard.Against.Empty(dto.Area);
            Guard.Against.Empty(dto.Author);
            Guard.Against.Empty(dto.Description);

            dto.AddDomainEvent(HomePageSearchDataRecordedEvent.Create(dto));

            return dto;
        }
    }
}