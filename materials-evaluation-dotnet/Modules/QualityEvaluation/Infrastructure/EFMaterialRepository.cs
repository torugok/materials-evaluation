using AutoMapper;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure
{
    public class EFMaterialRepository : IMaterialRepository
    {
        public List<Material> Seen { get; set; } // FIXME: buscar alternativa para despacho de eventos

        private readonly Database.DatabaseContext _context;
        private readonly IMapper _mapper;

        public EFMaterialRepository(Database.DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            Seen = new List<Material>();
        }

        public async Task Insert(Material material)
        {
            await _context.AddAsync(new Database.Material(material.Id, material.Name));
            Seen.Add(material);
        }

        public async Task<Material?> Get(Guid id)
        {
            return await _mapper
                .ProjectTo<Material>(_context.Materials.Where(o => o.Id == id))
                .FirstOrDefaultAsync();
        }

        public Task Update(Material material)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material != null)
            {
                _context.Materials.Remove(material);
            }
        }
    }
}
