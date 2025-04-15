using AeC.AutomationChallenge.Domain.HomePage.Dtos;

namespace AeC.AutomationChallenge.Domain.HomePage
{
    public record HomePageSearchDataRecordedEvent(
        Guid Id,
        string Title,
        string Area,
        string Author,
        string Description,
        DateTime PublishinDate) : DomainEvent
    {
        public static HomePageSearchDataRecordedEvent Create(HomePageSearchDataDto homePageSearchData) =>
        new(homePageSearchData.Id,
            homePageSearchData.Title,
            homePageSearchData.Area,
            homePageSearchData.Author,
            homePageSearchData.Description,
            homePageSearchData.PublishingDate);
    }
}