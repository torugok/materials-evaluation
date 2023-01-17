using MaterialsEvaluation.Modules.QualityEvaluation.Domain;

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

        public Task<MaterialBatch> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(MaterialBatch materialBatch)
        {
            throw new NotImplementedException();

            Seen.Add(materialBatch);
        }

        public async Task Delete(Guid id)
        {
            var materialBatch = await Get(id);
            throw new NotImplementedException();
        }
    }
}
