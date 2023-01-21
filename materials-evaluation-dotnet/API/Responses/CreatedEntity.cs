namespace MaterialsEvaluation.API_Controllers
{
    public class CreatedEntity
    {
        public Guid Id { get; }

        public CreatedEntity(Guid id)
        {
            Id = id;
        }
    }
}
