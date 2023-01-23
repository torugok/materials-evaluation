using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class DeleteMaterialCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public DeleteMaterialCommand() { }

        public DeleteMaterialCommand(Guid id)
        {
            Id = id;
        }
    }
}
