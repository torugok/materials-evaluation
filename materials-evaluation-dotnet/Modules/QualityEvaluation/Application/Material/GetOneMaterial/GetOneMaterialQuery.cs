using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetOneMaterialQuery : IRequest<MaterialDto>
    {
        public Guid Id { get; set; }

        public GetOneMaterialQuery(Guid id)
        {
            Id = id;
        }
    }
}
