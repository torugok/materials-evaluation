using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure
{
    public class EFMaterialBatchRepository : IMaterialBatchRepository
    {
        public List<MaterialBatch> Seen { get; set; } // FIXME: buscar alternativa para despacho de eventos

        private readonly Database.DatabaseContext _context;

        public EFMaterialBatchRepository(Database.DatabaseContext context)
        {
            _context = context;
            Seen = new List<MaterialBatch>();
        }

        public async Task Insert(MaterialBatch materialBatch)
        {
            await _context.AddAsync(
                new Database.MaterialBatch(
                    materialBatch.Id,
                    materialBatch.Material.Id,
                    materialBatch.QualityVision.Id,
                    materialBatch.CreatedAt,
                    materialBatch.AmountOfTests,
                    materialBatch.CalculatedAt,
                    materialBatch.Status.ToString()
                )
            );

            Seen.Add(materialBatch);
        }

        public async Task<MaterialBatch> Get(Guid id)
        {
            var rawItem = await _context.MaterialBatches
                .Include("MaterialBatchTests")
                .Include("Material")
                .Include("QualityVision.QualityVisionProperties.QualityProperty")
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
            return new MaterialBatch(
                rawItem.Id,
                new Material(rawItem.Material.Id, rawItem.Material.Name),
                new QualityVision(
                    rawItem.QualityVision.Id,
                    rawItem.QualityVision.MaterialId,
                    rawItem.QualityVision.Name,
                    new AvaliationMethodology(
                        rawItem.QualityVision.AvaliationMinQuantity,
                        Enum.Parse<Grouping>(rawItem.QualityVision.AvaliationGrouping),
                        Enum.Parse<CalculationType>(rawItem.QualityVision.AvaliationCalculationType)
                    ),
                    rawItem.QualityVision.QualityVisionProperties != null
                        ? rawItem.QualityVision.QualityVisionProperties.ConvertAll(
                            o =>
                                new QualityProperty
                                {
                                    Id = o.QualityProperty.Id,
                                    Acronym = o.QualityProperty.Acronym,
                                    Description = o.QualityProperty.Description,
                                    Type = Enum.Parse<PropertyTypes>(o.QualityProperty.Type),
                                    QuantitativeParams = new QuantitativeParams(
                                        o.QualityProperty.QuantitativeDecimals,
                                        o.QualityProperty.QuantitativeUnit,
                                        o.QualityProperty.QuantitativeNominalValue,
                                        o.QualityProperty.QuantitativeInferiorLimit,
                                        o.QualityProperty.QuantitativeSuperiorLimit
                                    )
                                }
                        )
                        : new List<QualityProperty>()
                ),
                rawItem.CreatedAt,
                rawItem.AmountOfTests,
                rawItem.CalculatedAt,
                rawItem.MaterialBatchTests.ConvertAll(
                    o => new Test(o.QualityPropertyId, o.ResultQualitative, o.ResultQuantitative)
                ),
                Enum.Parse<Status>(rawItem.Status)
            );
        }

        public async Task Update(MaterialBatch materialBatch)
        {
            var rawItem = await _context.MaterialBatches
                .Include("MaterialBatchTests")
                .Where(m => m.Id == materialBatch.Id)
                .FirstOrDefaultAsync();

            if (rawItem != null)
            {
                if (rawItem.MaterialBatchTests != null)
                {
                    _context.MaterialBatchTests.RemoveRange(rawItem.MaterialBatchTests);
                }

                if (materialBatch.Tests.Count > 0)
                {
                    _context.MaterialBatchTests.BulkInsert(
                        materialBatch.Tests.ConvertAll(
                            o =>
                                new Database.MaterialBatchTests(
                                    Guid.NewGuid(),
                                    materialBatch.Id,
                                    o.QualityPropertyId,
                                    o.ResultQualitative,
                                    o.ResultQuantitative,
                                    o.Result
                                )
                        )
                    );
                }

                rawItem.AmountOfTests = materialBatch.AmountOfTests;
                rawItem.Status = materialBatch.Status.ToString();
            }

            Seen.Add(materialBatch);
        }

        public async Task Delete(Guid id)
        {
            var materialBatch = await _context.MaterialBatches.FindAsync(id);
            if (materialBatch != null)
            {
                _context.MaterialBatches.Remove(materialBatch);
            }
        }
    }
}
