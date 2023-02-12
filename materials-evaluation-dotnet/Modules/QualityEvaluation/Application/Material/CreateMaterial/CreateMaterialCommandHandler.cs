using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MaterialsEvaluation.Shared.Domain;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMaterialCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            CreateMaterialCommand request,
            CancellationToken cancellationToken
        )
        {
            var material = Material.Create(request.Name);

            await _unitOfWork.MaterialRepository.Insert(material);
            await _unitOfWork.Commit(cancellationToken);

            return material.Id;
        }
    }
}
