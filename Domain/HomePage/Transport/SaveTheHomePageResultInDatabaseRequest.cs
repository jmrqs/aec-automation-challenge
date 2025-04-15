namespace AeC.AutomationChallenge.Domain.HomePage.Transport
{
    public class SaveTheHomePageResultInDatabaseRequest
    {

        public Guid Id { get; set; } = Guid.Empty!;
        public string Title { get; set; } = null!;

        public string Area { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime PublishingDate { get; set; } = DateTime.MinValue!;
    }
}
