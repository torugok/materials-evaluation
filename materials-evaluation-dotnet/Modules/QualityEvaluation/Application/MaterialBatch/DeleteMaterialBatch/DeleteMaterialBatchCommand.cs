using System.Runtime.Serialization;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    [DataContract]
    public class DeleteMaterialBatchCommand : IRequest<Guid>
    {
        [DataMember]
        public Guid Id { get; set; }

        public DeleteMaterialBatchCommand() { }

        public DeleteMaterialBatchCommand(Guid id)
        {
            Id = id;
        }
    }
}
