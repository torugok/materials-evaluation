using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class CreateMaterialCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        // Empty constructor for ASP.NET
        public CreateMaterialCommand() { }

        public CreateMaterialCommand(string name)
        {
            Name = name;
        }
    }
}
