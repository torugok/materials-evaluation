namespace MaterialsEvaluation.Shared.Domain
{
    public abstract class DomainEvent
    {
        public Guid Id { get; }

        public DateTime OccurredOn { get; }

        public DomainEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
        }
    }
}
