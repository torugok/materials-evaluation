using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class DeleteQualityPropertyCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public DeleteQualityPropertyCommand() { }

        public DeleteQualityPropertyCommand(Guid id)
        {
            Id = id;
        }
    }
}
