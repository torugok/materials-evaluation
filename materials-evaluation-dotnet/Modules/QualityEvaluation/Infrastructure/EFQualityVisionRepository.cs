using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure
{
    public class EFQualityVisionRepository : IQualityVisionRepository
    {
        public List<QualityVision> Seen { get; set; } // FIXME: buscar alternativa para despacho de eventos

        private readonly Database.DatabaseContext _context;

        public EFQualityVisionRepository(Database.DatabaseContext context)
        {
            _context = context;
            Seen = new List<QualityVision>();
        }

        public async Task Insert(QualityVision qualityVision)
        {
            var qualityVisionProperties = new List<Database.QualityVisionProperties>();

            // TODO: refatorar para usar LINQ
            foreach (QualityProperty qualityProperty in qualityVision.QualityProperties)
            {
                qualityVisionProperties.Add(
                    new Database.QualityVisionProperties(
                        Guid.NewGuid(),
                        qualityVision.Id,
                        qualityProperty.Id
                    )
                );
            }

            await _context.AddAsync(
                new Database.QualityVision(
                    qualityVision.Id,
                    qualityVision.Name,
                    qualityVision.AvaliationMethodology.MinQuantity,
                    qualityVision.AvaliationMethodology.Grouping.ToString(),
                    qualityVision.AvaliationMethodology.CalculationType.ToString(),
                    qualityVision.MaterialId,
                    qualityVisionProperties
                )
            );

            Seen.Add(qualityVision);
        }

        public async Task<QualityVision> Get(Guid id)
        {
            var rawItem = await _context.QualityVisions
                .Include("QualityVisionProperties.QualityProperty")
                .Where(q => q.Id == id)
                .FirstOrDefaultAsync();
            return new QualityVision(
                rawItem.Id,
                rawItem.MaterialId,
                rawItem.Name,
                new AvaliationMethodology(
                    rawItem.AvaliationMinQuantity,
                    Enum.Parse<Grouping>(rawItem.AvaliationGrouping),
                    Enum.Parse<CalculationType>(rawItem.AvaliationCalculationType)
                ),
                rawItem.QualityVisionProperties != null
                    ? rawItem.QualityVisionProperties
                        .Select(
                            o =>
                                new QualityProperty
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
                    : new List<QualityProperty>()
            );
        }

        public Task Update(QualityVision qualityVision)
        {
            throw new NotImplementedException();

            Seen.Add(qualityVision);
        }

        public async Task Delete(Guid id)
        {
            var qualityVision = await Get(id);
            throw new NotImplementedException();
        }
    }
}
