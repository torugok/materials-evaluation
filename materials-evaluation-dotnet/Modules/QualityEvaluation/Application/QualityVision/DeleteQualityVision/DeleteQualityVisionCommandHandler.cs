using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class DeleteQualityVisionCommandHandler
        : IRequestHandler<DeleteQualityVisionCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteQualityVisionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            DeleteQualityVisionCommand request,
            CancellationToken cancellationToken
        )
        {
            await _unitOfWork.QualityVisionRepository.Delete(request.Id);
            await _unitOfWork.Commit(cancellationToken);

            return request.Id;
        }
    }
}
