using AeC.AutomationChallenge.Domain.Interfaces.Services;

namespace AeC.AutomationChallenge.Application.HomePage.Commands.RecordSearchData
{
    public record RecordHomePageSearchDataCommand(string SearchTerm) : IRequest<Guid>;

    public class CreateCustomerCommandHandler : IRequestHandler<RecordHomePageSearchDataCommand, Guid>
    {
        private readonly IGetHomePageSearchDataService _service;

        public CreateCustomerCommandHandler(
            IGetHomePageSearchDataService service)
        {
            _service = service;
        }

        public async Task<Guid> Handle(RecordHomePageSearchDataCommand request, CancellationToken cancellationToken)
        {
            var serviceResult = await _service.GetHomePageSearchData(request.SearchTerm, cancellationToken);
            return serviceResult.Id;
        }
    }
}