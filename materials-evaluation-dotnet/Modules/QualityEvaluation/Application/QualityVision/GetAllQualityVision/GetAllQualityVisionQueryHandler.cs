using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetAllQualityVisionQueryHandler
        : IRequestHandler<GetAllQualityVisionQuery, List<QualityVisionDto>>
    {
        private readonly Database.DatabaseContext _context;

        public GetAllQualityVisionQueryHandler(Database.DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<QualityVisionDto>> Handle(
            GetAllQualityVisionQuery request,
            CancellationToken cancellationToken
        )
        {
            var qualityVisionRaw = await _context.QualityVisions
                .Include(b => b.QualityVisionProperties)
                .ToListAsync(cancellationToken);
            var qualityVisionsResult = new List<QualityVisionDto>();

            foreach (var rawItem in qualityVisionRaw)
            {
                qualityVisionsResult.Add(
                    new QualityVisionDto(
                        rawItem.Id,
                        rawItem.Name,
                        new AvaliationMethodology(
                            rawItem.AvaliationMinQuantity,
                            Enum.Parse<Grouping>(rawItem.AvaliationGrouping),
                            Enum.Parse<CalculationType>(rawItem.AvaliationCalculationType)
                        ),
                        rawItem.QualityVisionProperties != null
                            ? (from c in rawItem.QualityVisionProperties select c.Id).ToList()
                            : new List<Guid>()
                    )
                );
            }
            return qualityVisionsResult;
        }
    }
}
