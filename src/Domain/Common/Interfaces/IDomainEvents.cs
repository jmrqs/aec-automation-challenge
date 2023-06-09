using AeC.AutomationChallenge.Domain.Common.Base.AeC.AutomationChallenge.Domain.Common.Base;

namespace AeC.AutomationChallenge.Domain.Common.Interfaces
{
    public interface IDomainEvents
    {
        IReadOnlyList<DomainEvent> DomainEvents { get; }

        void AddDomainEvent(DomainEvent domainEvent);

        void RemoveDomainEvent(DomainEvent domainEvent);

        void ClearDomainEvents();
    }
}