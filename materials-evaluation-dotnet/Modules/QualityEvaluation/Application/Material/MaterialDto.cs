namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class MaterialDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public MaterialDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
