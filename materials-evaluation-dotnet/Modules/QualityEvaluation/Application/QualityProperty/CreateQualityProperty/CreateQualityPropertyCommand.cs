using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class CreateQualityPropertyCommand : IRequest<Guid>
    {
        public string Acronym { get; set; }

        public string Description { get; set; }

        public PropertyTypes Type { get; set; }

        public QuantitativeParams? QuantitativeParams { get; set; }

        // Empty constructor for ASP.NET
        public CreateQualityPropertyCommand() { }

        public CreateQualityPropertyCommand(
            string acronym,
            string description,
            PropertyTypes type,
            QuantitativeParams? quantitativeParams
        )
        {
            Acronym = acronym;
            Description = description;
            Type = type;
            QuantitativeParams = quantitativeParams;
        }
    }
}
