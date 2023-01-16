using System.Text.Json.Serialization;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class QualityVisionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public AvaliationMethodology AvaliationMethodology { get; set; }

        public QualityVisionDto() { }

        public QualityVisionDto(Guid id, string name, AvaliationMethodology avaliationMethodology)
        {
            Id = id;
            Name = name;
            AvaliationMethodology = avaliationMethodology;
        }
    }
}
