using Microsoft.Extensions.Logging;

namespace AeC.AutomationChallenge.Application.HomePage.EventHandlers.RecordSearchData
{
    public class HomePageSearchDataRecordedEventHandler : INotificationHandler<HomePageSearchDataRecordedEvent>
    {
        private readonly ILogger<HomePageSearchDataRecordedEventHandler> _logger;

        public HomePageSearchDataRecordedEventHandler(ILogger<HomePageSearchDataRecordedEventHandler> logger) => _logger = logger;

        public Task Handle(HomePageSearchDataRecordedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{Handler}: {@Notification} was recorded.",
                nameof(HomePageSearchDataRecordedEventHandler),
                notification);

            return Task.CompletedTask;
        }
    }
}