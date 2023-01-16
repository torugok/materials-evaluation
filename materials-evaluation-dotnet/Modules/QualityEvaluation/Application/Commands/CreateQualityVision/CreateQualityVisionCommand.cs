using System.Runtime.Serialization;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    [DataContract]
    public class CreateQualityVisionCommand : IRequest<QualityVisionDto>
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Guid MaterialId { get; set; }

        [DataMember]
        public AvaliationMethodology AvaliationMethodology { get; set; }

        [DataMember]
        public List<Guid> QualityProperties { get; set; }

        public CreateQualityVisionCommand() { }

        public CreateQualityVisionCommand(
            string name,
            Guid materialId,
            AvaliationMethodology avaliationMethodology,
            List<Guid> qualityProperties
        )
        {
            Name = name;
            MaterialId = materialId;
            AvaliationMethodology = avaliationMethodology;
            QualityProperties = qualityProperties;
        }
    }
}
