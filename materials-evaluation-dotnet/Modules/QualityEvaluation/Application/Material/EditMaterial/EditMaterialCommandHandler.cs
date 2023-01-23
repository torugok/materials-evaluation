using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MaterialsEvaluation.Shared.Application;
using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands
{
    public class EditMaterialCommandHandler : IRequestHandler<EditMaterialCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditMaterialCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(
            EditMaterialCommand request,
            CancellationToken cancellationToken
        )
        {
            var material = await _unitOfWork.MaterialRepository.Get(request.Id);
            if (material == null)
            {
                throw new NotFoundException("Material não encontrado!");
            }

            material.Edit(request.Name);

            _unitOfWork.MaterialRepository.Update(material);
            await _unitOfWork.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
