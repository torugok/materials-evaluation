using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class DeleteQualityPropertyCommandHandler
        : IRequestHandler<DeleteQualityPropertyCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteQualityPropertyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            DeleteQualityPropertyCommand request,
            CancellationToken cancellationToken
        )
        {
            await _unitOfWork.QualityPropertyRepository.Delete(request.Id);
            await _unitOfWork.Commit(cancellationToken);

            return request.Id;
        }
    }
}
