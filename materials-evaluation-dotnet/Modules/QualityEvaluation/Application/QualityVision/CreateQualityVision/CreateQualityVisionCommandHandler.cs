using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class CreateQualityVisionCommandHandler
        : IRequestHandler<CreateQualityVisionCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateQualityVisionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            CreateQualityVisionCommand request,
            CancellationToken cancellationToken
        )
        {
            var qualityVision = QualityVision.Create(
                request.MaterialId,
                request.Name,
                request.AvaliationMethodology,
                request.QualityProperties
            );

            await _unitOfWork.QualityVisionRepository.Insert(qualityVision);
            await _unitOfWork.Commit(cancellationToken);

            return qualityVision.Id;
        }
    }
}
