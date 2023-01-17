using System.Runtime.Serialization;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    [DataContract]
    public class DeleteQualityVisionCommand : IRequest<Guid>
    {
        [DataMember]
        public Guid Id { get; set; }

        public DeleteQualityVisionCommand() { }

        public DeleteQualityVisionCommand(Guid id)
        {
            Id = id;
        }
    }
}
