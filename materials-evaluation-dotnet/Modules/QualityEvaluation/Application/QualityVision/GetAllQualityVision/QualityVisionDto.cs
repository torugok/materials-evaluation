using System.Runtime.Serialization;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    [DataContract]
    public class QualityVisionDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Guid MaterialId { get; set; }

        [DataMember]
        public AvaliationMethodology AvaliationMethodology { get; set; }

        [DataMember]
        public List<QualityPropertyDto> QualityProperties { get; set; }

        public QualityVisionDto() { }

        public QualityVisionDto(
            Guid id,
            string name,
            Guid materialId,
            AvaliationMethodology avaliationMethodology,
            List<QualityPropertyDto> qualityProperties
        )
        {
            Id = id;
            Name = name;
            MaterialId = materialId;
            AvaliationMethodology = avaliationMethodology;
            QualityProperties = qualityProperties;
        }
    }
}
