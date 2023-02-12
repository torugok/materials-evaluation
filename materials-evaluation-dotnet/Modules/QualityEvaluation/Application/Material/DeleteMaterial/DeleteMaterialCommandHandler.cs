using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMaterialCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            DeleteMaterialCommand request,
            CancellationToken cancellationToken
        )
        {
            await _unitOfWork.MaterialRepository.Delete(request.Id);
            await _unitOfWork.Commit(cancellationToken);

            return request.Id;
        }
    }
}
