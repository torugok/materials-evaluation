using AutoMapper;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure
{
    public class EFMaterialRepository : IMaterialRepository
    {
        public List<Material> Seen { get; set; } // FIXME: buscar alternativa para despacho de eventos
        private readonly DbSet<Material> _dbSet;

        public EFMaterialRepository(Database.DatabaseContext context)
        {
            _dbSet = context.Set<Material>();
            Seen = new List<Material>();
        }

        public async Task Insert(Material material)
        {
            await _dbSet.AddAsync(material);
            Seen.Add(material);
        }

        public async Task<Material?> Get(Guid id)
        {
            return await _dbSet.Where(o => o.Id == id).FirstOrDefaultAsync();
        }

        public void Update(Material material)
        {
            _dbSet.Update(material);
        }

        public async Task Delete(Guid id)
        {
            var material = await _dbSet.FindAsync(id);
            if (material != null)
            {
                _dbSet.Remove(material);
            }
        }
    }
}
