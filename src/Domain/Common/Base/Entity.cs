namespace AeC.AutomationChallenge.Domain.Common.Base
{
    public abstract class Entity<TId>
    {
        public required TId Id { get; init; }
        public DateTimeOffset CreatedAt { get; private set; }
        public string? CreatedBy { get; private set; }
        public DateTimeOffset? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }
    }
}