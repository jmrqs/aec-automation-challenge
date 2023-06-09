using AeC.AutomationChallenge.Domain.HomePage.Dtos;
using AeC.AutomationChallenge.Domain.HomePage.Transport;
using AeC.AutomationChallenge.Domain.Interfaces.Repositories;
using AeC.AutomationChallenge.Domain.Interfaces.Services;

namespace AeC.AutomationChallenge.Application.HomePage.Commands.RecordSearchData
{
    public record RecordHomePageSearchDataCommand(string SearchTerm) : IRequest<Guid>;

    public class CreateCustomerCommandHandler : IRequestHandler<RecordHomePageSearchDataCommand, Guid>
    {
        private readonly IGetHomePageSearchDataService _service;
        private readonly IRecordHomePageSearchDataRepository _repository;

        public CreateCustomerCommandHandler(
            IGetHomePageSearchDataService service,
            IRecordHomePageSearchDataRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        public async Task<Guid> Handle(RecordHomePageSearchDataCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Guid.NewGuid());
        }
    }
}