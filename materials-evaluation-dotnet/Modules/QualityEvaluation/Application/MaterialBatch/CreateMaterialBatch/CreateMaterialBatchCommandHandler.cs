using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class CreateMaterialBatchCommandHandler
        : IRequestHandler<CreateMaterialBatchCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMaterialBatchCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            CreateMaterialBatchCommand request,
            CancellationToken cancellationToken
        )
        {
            var materialBatch = MaterialBatch.Create(
                await _unitOfWork.MaterialRepository.Get(request.MaterialId),
                await _unitOfWork.QualityVisionRepository.Get(request.QualityVisionId)
            );

            await _unitOfWork.MaterialBatchRepository.Insert(materialBatch);
            await _unitOfWork.Commit(cancellationToken);

            return materialBatch.Id;
        }
    }
}
