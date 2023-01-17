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
                .Include("QualityVisionProperties.QualityProperty")
                .ToListAsync(cancellationToken);
            var qualityVisionsResult = new List<QualityVisionDto>();

            foreach (var rawItem in qualityVisionRaw)
            {
                qualityVisionsResult.Add(
                    new QualityVisionDto(
                        rawItem.Id,
                        rawItem.Name,
                        rawItem.MaterialId,
                        new AvaliationMethodology(
                            rawItem.AvaliationMinQuantity,
                            Enum.Parse<Grouping>(rawItem.AvaliationGrouping),
                            Enum.Parse<CalculationType>(rawItem.AvaliationCalculationType)
                        ),
                        rawItem.QualityVisionProperties != null
                            ? rawItem.QualityVisionProperties
                                .Select(
                                    o =>
                                        new QualityPropertyDto
                                        {
                                            Id = o.QualityProperty.Id,
                                            Acronym = o.QualityProperty.Acronym,
                                            Description = o.QualityProperty.Description,
                                            Type = o.QualityProperty.Type,
                                            QuantitativeParams = new QuantitativeParams(
                                                o.QualityProperty.QuantitativeDecimals,
                                                o.QualityProperty.QuantitativeUnit,
                                                o.QualityProperty.QuantitativeNominalValue,
                                                o.QualityProperty.QuantitativeInferiorLimit,
                                                o.QualityProperty.QuantitativeSuperiorLimit
                                            )
                                        }
                                )
                                .ToList()
                            : new List<QualityPropertyDto>()
                    )
                );
            }

            return qualityVisionsResult;
        }
    }
}
