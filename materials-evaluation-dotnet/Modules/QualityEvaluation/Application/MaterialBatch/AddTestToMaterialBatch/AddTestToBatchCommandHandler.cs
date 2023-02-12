using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MaterialsEvaluation.Shared.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class AddTestToBatchCommandHandler : IRequestHandler<AddTestToBatchCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddTestToBatchCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            AddTestToBatchCommand request,
            CancellationToken cancellationToken
        )
        {
            var batch = await _unitOfWork.BatchRepository.Get(request.BatchId);
            if (batch == null)
            {
                throw new BusinessException("Lote não encontrado");
            }

            batch.AddTest(request.Tests);

            await _unitOfWork.BatchRepository.Update(batch);
            await _unitOfWork.Commit(cancellationToken);

            return batch.Id;
        }
    }
}
