using System.Runtime.Serialization;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    [DataContract]
    public class CheckTestsCommand : IRequest<Guid>
    {
        [DataMember]
        public Guid Id { get; set; }

        public CheckTestsCommand() { }

        public CheckTestsCommand(Guid id)
        {
            Id = id;
        }
    }
}
