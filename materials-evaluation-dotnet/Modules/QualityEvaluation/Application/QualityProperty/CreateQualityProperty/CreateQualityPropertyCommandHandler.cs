using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MaterialsEvaluation.Shared.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class CreateQualityPropertyCommandHandler
        : IRequestHandler<CreateQualityPropertyCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateQualityPropertyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            CreateQualityPropertyCommand request,
            CancellationToken cancellationToken
        )
        {
            var qualityProperty = QualityProperty.Create(
                request.acronym,
                request.description,
                request.type,
                request.quantitativeParams
            );

            await _unitOfWork.QualityPropertyRepository.Insert(qualityProperty);
            await _unitOfWork.Commit(cancellationToken);

            return qualityProperty.Id;
        }
    }
}
