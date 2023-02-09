using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetOneQualityPropertyQuery : IRequest<QualityPropertyDto>
    {
        public Guid Id { get; set; }

        public GetOneQualityPropertyQuery(Guid id)
        {
            Id = id;
        }
    }
}
