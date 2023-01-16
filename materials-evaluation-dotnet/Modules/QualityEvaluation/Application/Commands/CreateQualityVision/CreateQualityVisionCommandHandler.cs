using MediatR;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class CreateQualityVisionCommandHandler
        : IRequestHandler<CreateQualityVisionCommand, QualityVisionDto>
    {
        private readonly IQualityVisionRepository _qualityVisionRepository;

        public CreateQualityVisionCommandHandler(IQualityVisionRepository qualityVisionRepository)
        {
            this._qualityVisionRepository = qualityVisionRepository;
        }

        public async Task<QualityVisionDto> Handle(
            CreateQualityVisionCommand request,
            CancellationToken cancellationToken
        )
        {
            var qualityVision = QualityVision.Create(
                request.MaterialId,
                request.Name,
                request.AvaliationMethodology
            );
            await Task.Delay(0); // HACK: corrige erro temporario, remover isso
            return new QualityVisionDto(
                qualityVision.Id,
                qualityVision.Name,
                qualityVision.AvaliationMethodology
            );
        }
    }
}
