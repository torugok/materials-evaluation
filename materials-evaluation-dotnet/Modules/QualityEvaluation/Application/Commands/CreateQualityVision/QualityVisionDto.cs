using System.Runtime.Serialization;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    [DataContract]
    public class QualityVisionDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public AvaliationMethodology AvaliationMethodology { get; set; }

        [DataMember]
        public List<Guid> QualityProperties { get; set; }

        public QualityVisionDto() { }

        public QualityVisionDto(
            Guid id,
            string name,
            AvaliationMethodology avaliationMethodology,
            List<Guid> qualityProperties
        )
        {
            Id = id;
            Name = name;
            AvaliationMethodology = avaliationMethodology;
            QualityProperties = qualityProperties;
        }
    }
}
