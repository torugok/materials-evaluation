using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MaterialsEvaluation.Shared.Application;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class EditQualityPropertyCommandHandler
        : IRequestHandler<EditQualityPropertyCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditQualityPropertyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(
            EditQualityPropertyCommand request,
            CancellationToken cancellationToken
        )
        {
            var qualityProperty = await _unitOfWork.QualityPropertyRepository.Get(request.Id);
            if (qualityProperty == null)
            {
                throw new NotFoundException("Característica de qualidade não encontrada!");
            }

            qualityProperty.Edit(request.Acronym, request.Description);

            _unitOfWork.QualityPropertyRepository.Update(qualityProperty);
            await _unitOfWork.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
