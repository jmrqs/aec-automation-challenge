namespace AeC.AutomationChallenge.Domain.Common.Base
{
    public abstract class Entity<TId>
    {
        public required TId Id { get; init; }
    }
}