using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class EditQualityPropertyCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Acronym { get; set; }

        public string Description { get; set; }

        public PropertyTypes Type { get; set; }

        public QuantitativeParams? QuantitativeParams { get; set; }

        public EditQualityPropertyCommand() { }

        public EditQualityPropertyCommand(
            Guid id,
            string acronym,
            string description,
            PropertyTypes type,
            QuantitativeParams? quantitativeParams
        )
        {
            PropertyTypes.Qualitative;
            
            Id = id;
            Acronym = acronym;
            Description = description;
            Type = type;
            QuantitativeParams = quantitativeParams;
        }
    }
}
