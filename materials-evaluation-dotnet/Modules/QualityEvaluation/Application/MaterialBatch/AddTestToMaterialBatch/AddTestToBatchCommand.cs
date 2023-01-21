using System.Runtime.Serialization;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    [DataContract]
    public class AddTestToBatchCommand : IRequest<Guid>
    {
        [DataMember]
        public Guid BatchId { get; set; }

        [DataMember]
        public List<Test> Tests { get; set; }

        public AddTestToBatchCommand() { }

        public AddTestToBatchCommand(Guid batchId, List<Test> tests)
        {
            BatchId = batchId;
            Tests = tests;
        }
    }
}
