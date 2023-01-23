using MaterialsEvaluation.Shared.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public class Material : AggregateRoot
    {
        public string Name { get; private set; }

        // Empty constructor for EF
        protected Material() { }

        private Material(string name)
        {
            Name = name;
        }

        public static Material Create(string name)
        {
            // TODO: adicionar evento de MaterialCreated
            return new Material(name);
        }

        public void Edit(string name)
        {
            // TODO: adicionar evento de MaterialEdited
            Name = name;
        }
    }
}
