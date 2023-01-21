using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MaterialsEvaluation.Shared.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class CheckTestsCommandHandler : IRequestHandler<CheckTestsCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckTestsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            CheckTestsCommand request,
            CancellationToken cancellationToken
        )
        {
            var batch = await _unitOfWork.BatchRepository.Get(request.Id);
            if (batch == null)
            {
                throw new BusinessException("Lote não encontrado");
            }

            batch.CheckTests();

            await _unitOfWork.BatchRepository.Update(batch);
            await _unitOfWork.Commit(cancellationToken);

            return batch.Id;
        }
    }
}
