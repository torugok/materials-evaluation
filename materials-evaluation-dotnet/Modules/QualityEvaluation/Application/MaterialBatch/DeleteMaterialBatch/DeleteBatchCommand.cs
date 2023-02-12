using System.Runtime.Serialization;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    [DataContract]
    public class DeleteBatchCommand : IRequest<Guid>
    {
        [DataMember]
        public Guid Id { get; set; }

        public DeleteBatchCommand() { }

        public DeleteBatchCommand(Guid id)
        {
            Id = id;
        }
    }
}
