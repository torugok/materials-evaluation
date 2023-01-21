using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MaterialsEvaluation.Shared.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class CreateBatchCommandHandler : IRequestHandler<CreateBatchCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBatchCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            CreateBatchCommand request,
            CancellationToken cancellationToken
        )
        {
            var material = await _unitOfWork.MaterialRepository.Get(request.MaterialId);
            var qualityVision = await _unitOfWork.QualityVisionRepository.Get(
                request.QualityVisionId
            );
            if (material == null || qualityVision == null)
            {
                throw new BusinessException("Material e Visão de qualidade são necessárias");
            }

            var batch = Batch.Create(material, qualityVision);

            await _unitOfWork.BatchRepository.Insert(batch);
            await _unitOfWork.Commit(cancellationToken);

            return batch.Id;
        }
    }
}
