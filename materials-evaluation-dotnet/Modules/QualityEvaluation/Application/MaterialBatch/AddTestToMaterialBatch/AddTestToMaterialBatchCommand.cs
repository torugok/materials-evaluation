using System.Runtime.Serialization;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    [DataContract]
    public class AddTestToMaterialBatchCommand : IRequest<Guid>
    {
        [DataMember]
        public Guid MaterialBatchId { get; set; }

        [DataMember]
        public List<Test> Tests { get; set; }

        public AddTestToMaterialBatchCommand() { }

        public AddTestToMaterialBatchCommand(Guid materialBatchId, List<Test> tests)
        {
            MaterialBatchId = materialBatchId;
            Tests = tests;
        }
    }
}
