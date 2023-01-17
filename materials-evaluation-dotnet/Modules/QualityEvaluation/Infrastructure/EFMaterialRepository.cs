using MaterialsEvaluation.Modules.QualityEvaluation.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure
{
    public class EFMaterialRepository : IMaterialRepository
    {
        public List<Material> Seen { get; set; } // FIXME: buscar alternativa para despacho de eventos

        private readonly Database.DatabaseContext _context;

        public EFMaterialRepository(Database.DatabaseContext context)
        {
            _context = context;
            Seen = new List<Material>();
        }

        public async Task Insert(Material material)
        {
            await _context.AddAsync(new Database.Material(material.Id, material.Name));
            Seen.Add(material);
        }

        public async Task<Material> Get(Guid id)
        {
            var material = await _context.Materials.FindAsync(id);
            return new Material(material.Id, material.Name);
        }

        public Task Update(Material material)
        {
            throw new NotImplementedException();

            Seen.Add(material);
        }

        public async Task Delete(Guid id)
        {
            var material = await Get(id);
            throw new NotImplementedException();
        }
    }
}
