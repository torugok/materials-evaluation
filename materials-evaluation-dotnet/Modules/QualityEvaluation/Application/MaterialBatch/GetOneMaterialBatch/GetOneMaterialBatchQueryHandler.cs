using AutoMapper;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetOneMaterialBatchQueryHandler
        : IRequestHandler<GetOneMaterialBatchQuery, MaterialBatchDto?>
    {
        private readonly Database.DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetOneMaterialBatchQueryHandler(Database.DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MaterialBatchDto?> Handle(
            GetOneMaterialBatchQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _mapper
                .ProjectTo<MaterialBatchDto>(
                    _context.MaterialBatches
                        .Include("QualityVision.QualityVisionProperties.QualityProperty")
                        .Include("Material")
                        .Include("MaterialBatchTests.QualityProperty")
                        .Where(q => q.Id == request.Id),
                    null
                )
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
