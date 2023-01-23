using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class EditMaterialCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public EditMaterialCommand() { }

        public EditMaterialCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
