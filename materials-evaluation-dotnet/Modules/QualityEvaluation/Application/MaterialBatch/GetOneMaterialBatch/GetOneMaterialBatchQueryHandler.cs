using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetOneMaterialBatchQueryHandler
        : IRequestHandler<GetOneMaterialBatchQuery, MaterialBatchDto>
    {
        private readonly Database.DatabaseContext _context;

        public GetOneMaterialBatchQueryHandler(Database.DatabaseContext context)
        {
            _context = context;
        }

        public async Task<MaterialBatchDto> Handle(
            GetOneMaterialBatchQuery request,
            CancellationToken cancellationToken
        )
        {
            var materialBatchRaw = await _context.MaterialBatches
                .Include("QualityVision.QualityVisionProperties.QualityProperty")
                .Include("Material")
                .Include("MaterialBatchTests.QualityProperty")
                .Where(q => q.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            return new MaterialBatchDto(
                materialBatchRaw.Id,
                new MaterialDto(materialBatchRaw.Material.Id, materialBatchRaw.Material.Name),
                GetAllQualityVisionQueryHandler.ConvertToDto(materialBatchRaw.QualityVision),
                materialBatchRaw.CreatedAt,
                materialBatchRaw.AmountOfTests,
                materialBatchRaw.CalculatedAt,
                Enum.Parse<Status>(materialBatchRaw.Status),
                materialBatchRaw.MaterialBatchTests != null
                    ? materialBatchRaw.MaterialBatchTests
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
            );
        }
    }
}
