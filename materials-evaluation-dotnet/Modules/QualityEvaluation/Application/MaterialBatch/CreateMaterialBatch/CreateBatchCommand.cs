using System.Runtime.Serialization;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    [DataContract]
    public class CreateBatchCommand : IRequest<Guid>
    {
        [DataMember]
        public Guid MaterialId { get; set; }

        [DataMember]
        public Guid QualityVisionId { get; set; }

        public CreateBatchCommand() { }

        public CreateBatchCommand(Guid materialId, Guid qualityVisionId)
        {
            MaterialId = materialId;
            QualityVisionId = qualityVisionId;
        }
    }
}
