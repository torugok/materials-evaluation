using FluentValidation;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class CreateQualityVisionValidator : AbstractValidator<CreateQualityVisionCommand>
    {
        public CreateQualityVisionValidator()
        {
            RuleFor(x => x.Name).Length(0, 50);
            RuleFor(x => x.AvaliationMethodology.MinQuantity).GreaterThan(0);
        }
    }
}
