using System.Runtime.Serialization;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    [DataContract]
    public class CheckTestsMaterialBatchCommand : IRequest<Guid>
    {
        [DataMember]
        public Guid Id { get; set; }

        public CheckTestsMaterialBatchCommand() { }

        public CheckTestsMaterialBatchCommand(Guid id)
        {
            Id = id;
        }
    }
}
