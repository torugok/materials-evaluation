using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class DeleteMaterialBatchCommandHandler
        : IRequestHandler<DeleteMaterialBatchCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMaterialBatchCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            DeleteMaterialBatchCommand request,
            CancellationToken cancellationToken
        )
        {
            await _unitOfWork.MaterialBatchRepository.Delete(request.Id);
            await _unitOfWork.Commit(cancellationToken);

            return request.Id;
        }
    }
}
