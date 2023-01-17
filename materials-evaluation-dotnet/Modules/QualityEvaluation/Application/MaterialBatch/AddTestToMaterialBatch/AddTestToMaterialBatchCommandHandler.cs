using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class AddTestToMaterialBatchCommandHandler
        : IRequestHandler<AddTestToMaterialBatchCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddTestToMaterialBatchCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            AddTestToMaterialBatchCommand request,
            CancellationToken cancellationToken
        )
        {
            var materialBatch = await _unitOfWork.MaterialBatchRepository.Get(
                request.MaterialBatchId
            );

            materialBatch.AddTest(request.Tests);

            await _unitOfWork.MaterialBatchRepository.Update(materialBatch);
            await _unitOfWork.Commit(cancellationToken);

            return materialBatch.Id;
        }
    }
}
