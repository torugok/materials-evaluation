using System.Runtime.Serialization;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    [DataContract]
    public class CheckTestsCommand : IRequest<Status>
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
