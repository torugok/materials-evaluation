using MaterialsEvaluation.Shared.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public class Material : AggregateRoot
    {
        public string Name { get; set; }

        public Material(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
