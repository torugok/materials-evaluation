using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class DeleteBatchCommandHandler : IRequestHandler<DeleteBatchCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBatchCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            DeleteBatchCommand request,
            CancellationToken cancellationToken
        )
        {
            await _unitOfWork.BatchRepository.Delete(request.Id);
            await _unitOfWork.Commit(cancellationToken);

            return request.Id;
        }
    }
}
