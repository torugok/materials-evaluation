using System.Text.Json.Serialization;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class CreateQualityVisionCommand : IRequest<QualityVisionDto>
    {
        public string Name { get; set; }

        public Guid MaterialId { get; set; }

        public AvaliationMethodology AvaliationMethodology { get; set; }

        public CreateQualityVisionCommand() { }

        public CreateQualityVisionCommand(
            string name,
            Guid materialId,
            AvaliationMethodology avaliationMethodology
        )
        {
            Name = name;
            MaterialId = materialId;
            AvaliationMethodology = avaliationMethodology;
        }
    }
}
