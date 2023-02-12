namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class QualityPropertyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public QualityPropertyDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
