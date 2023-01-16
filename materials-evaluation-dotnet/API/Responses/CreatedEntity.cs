namespace MaterialsEvaluation.API_Controllers
{
    public class CreatedEntity
    {
        public Guid Id { get; private set; }

        public CreatedEntity(Guid id)
        {
            Id = id;
        }
    }
}
