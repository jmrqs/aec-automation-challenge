namespace AeC.AutomationChallenge.Domain.HomePage.Transport
{
    public class HomePageSearchDataResponse
    {
        public string Title { get; private set; } = null!;

        public string Area { get; private set; } = null!;

        public string Author { get; private set; } = null!;

        public string Description { get; private set; } = null!;

        public DateTime PublishingDate { get; set; } = DateTime.MinValue!;
    }
}
