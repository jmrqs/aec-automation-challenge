namespace AeC.AutomationChallenge.Application.HomePage.Commands.RecordSearchData
{
    public class RecordHomePageSearchDataCommandValidator : AbstractValidator<RecordHomePageSearchDataCommand>
    {
        public RecordHomePageSearchDataCommandValidator()
        {
            RuleFor(p => p.SearchTerm)
                .NotEmpty();
        }
    }
}