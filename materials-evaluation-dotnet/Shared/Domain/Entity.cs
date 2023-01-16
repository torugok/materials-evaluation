namespace MaterialsEvaluation.Shared.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; }

        private List<DomainEvent> _domainEvents;

        public IReadOnlyCollection<DomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();

        public Entity()
        {
            Id = Guid.NewGuid();
            _domainEvents = new List<DomainEvent>();
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        protected void AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents ??= new List<DomainEvent>();
            _domainEvents.Add(domainEvent);
        }
    }
}
