using System;
using AutoMapper;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure
{
    public class EFBatchRepository : IBatchRepository
    {
        public List<Batch> Seen { get; set; } // FIXME: buscar alternativa para despacho de eventos

        private readonly Database.DatabaseContext _context;
        private readonly IMapper _mapper;

        public EFBatchRepository(Database.DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            Seen = new List<Batch>();
        }

        public async Task Insert(Batch batch)
        {
            await _context.AddAsync(
                new Database.Batch(
                    batch.Id,
                    batch.Material.Id,
                    batch.QualityVision.Id,
                    batch.CreatedAt,
                    batch.AmountOfTests,
                    batch.CalculatedAt,
                    batch.Status.ToString()
                )
            );

            Seen.Add(batch);
        }

        public async Task<Batch?> Get(Guid id)
        {
            return await _mapper
                .ProjectTo<Batch>(
                    _context.Batches
                        .Include("QualityVision.QualityProperties.QualityProperty")
                        .Include("Material")
                        .Include("Tests.QualityProperty"),
                    null
                )
                .FirstOrDefaultAsync();
        }

        public async Task Update(Batch batch)
        {
            var rawItem = await _context.Batches
                .Include("Tests")
                .Where(m => m.Id == batch.Id)
                .FirstOrDefaultAsync();

            if (rawItem != null)
            {
                if (rawItem.Tests != null)
                {
                    _context.Tests.RemoveRange(rawItem.Tests);
                }

                if (batch.Tests.Count > 0)
                {
                    _context.Tests.BulkInsert(
                        batch.Tests.ConvertAll(
                            o =>
                                new Database.Test(
                                    Guid.NewGuid(),
                                    batch.Id,
                                    o.QualityProperty.Id,
                                    o.ResultQualitative,
                                    o.ResultQuantitative,
                                    o.Passed
                                )
                        )
                    );
                }

                rawItem.AmountOfTests = batch.AmountOfTests;
                rawItem.Status = batch.Status.ToString();
            }

            Seen.Add(batch);
        }

        public async Task Delete(Guid id)
        {
            var batch = await _context.Batches.FindAsync(id);
            if (batch != null)
            {
                _context.Batches.Remove(batch);
            }
        }
    }
}
