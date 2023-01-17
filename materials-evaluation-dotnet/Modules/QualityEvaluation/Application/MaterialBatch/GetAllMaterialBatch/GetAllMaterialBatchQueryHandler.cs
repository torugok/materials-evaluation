using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetAllMaterialBatchQueryHandler
        : IRequestHandler<GetAllMaterialBatchQuery, List<MaterialBatchDto>>
    {
        private readonly Database.DatabaseContext _context;

        public GetAllMaterialBatchQueryHandler(Database.DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<MaterialBatchDto>> Handle(
            GetAllMaterialBatchQuery request,
            CancellationToken cancellationToken
        )
        {
            var materialBatchRaw = await _context.MaterialBatches
                .Include("QualityVision.QualityVisionProperties.QualityProperty")
                .Include("Material")
                .Include("MaterialBatchTests.QualityProperty")
                .ToListAsync(cancellationToken);
            var materialBatchResult = new List<MaterialBatchDto>();

            foreach (var rawItem in materialBatchRaw)
            {
                materialBatchResult.Add(
                    new MaterialBatchDto(
                        rawItem.Id,
                        new MaterialDto(rawItem.Material.Id, rawItem.Material.Name),
                        GetAllQualityVisionQueryHandler.ConvertToDto(rawItem.QualityVision),
                        rawItem.CreatedAt,
                        rawItem.AmountOfTests,
                        rawItem.CalculatedAt,
                        Enum.Parse<Status>(rawItem.Status),
                        rawItem.MaterialBatchTests != null
                            ? rawItem.MaterialBatchTests
                                .Select(
                                    o =>
                                        new TestDto
                                        {
                                            QualityProperty = new QualityPropertyDto
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
                                            },
                                            ResultQualitative = o.ResultQualitative,
                                            ResultQuantitative = o.ResultQuantitative
                                        }
                                )
                                .ToList()
                            : new List<TestDto>()
                    )
                );
            }

            return materialBatchResult;
        }
    }
}
