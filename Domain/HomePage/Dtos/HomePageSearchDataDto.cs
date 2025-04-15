using AeC.AutomationChallenge.Domain.Common.Base.AeC.AutomationChallenge.Domain.Common.Base;
using AeC.AutomationChallenge.Domain.HomePage.Transport;

namespace AeC.AutomationChallenge.Domain.HomePage.Dtos
{
    public class HomePageSearchDataDto : AggregateRoot<Guid>
    {
        public string Title { get; set; } = null!;

        public string Area { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime PublishingDate { get; set; } = DateTime.MinValue!;

        public static HomePageSearchDataDto Create(HomePageSearchDataDto dto)
        {
            Guard.Against.Empty(dto.Title);
            Guard.Against.Empty(dto.Area);
            Guard.Against.Empty(dto.Author);
            Guard.Against.Empty(dto.Description);

            dto.AddDomainEvent(HomePageSearchDataRecordedEvent.Create(dto));

            return dto;
        }

        public static HomePageSearchDataDto Create(SaveTheHomePageResultInDatabaseRequest request)
        {
            return new HomePageSearchDataDto()
            {
                Id = request.Id,
                Title = request.Title,
                Area = request.Area,
                Author = request.Author,
                Description = request.Description,
                PublishingDate = request.PublishingDate
            };
        }

        public static SaveTheHomePageResultInDatabaseResponse Response(HomePageSearchDataDto dto)
        {
            return new SaveTheHomePageResultInDatabaseResponse()
            {
                Id = dto.Id,
                Title = dto.Title,
                Area = dto.Area,
                Author = dto.Author,
                Description = dto.Description,
                PublishingDate = dto.PublishingDate
            };
        }
    }
}