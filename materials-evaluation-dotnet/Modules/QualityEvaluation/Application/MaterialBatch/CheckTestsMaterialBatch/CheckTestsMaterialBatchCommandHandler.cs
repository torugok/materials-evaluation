using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class CheckTestsMaterialBatchCommandHandler
        : IRequestHandler<CheckTestsMaterialBatchCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckTestsMaterialBatchCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            CheckTestsMaterialBatchCommand request,
            CancellationToken cancellationToken
        )
        {
            var materialBatch = await _unitOfWork.MaterialBatchRepository.Get(request.Id);

            materialBatch.CheckTests();

            await _unitOfWork.MaterialBatchRepository.Update(materialBatch);
            await _unitOfWork.Commit(cancellationToken);

            return materialBatch.Id;
        }
    }
}
