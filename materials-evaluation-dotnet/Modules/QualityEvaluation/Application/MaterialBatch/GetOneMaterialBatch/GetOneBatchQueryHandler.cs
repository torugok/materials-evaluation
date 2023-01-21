using AutoMapper;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetOneBatchQueryHandler : IRequestHandler<GetOneBatchQuery, BatchDto?>
    {
        private readonly Database.DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetOneBatchQueryHandler(Database.DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BatchDto?> Handle(
            GetOneBatchQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _mapper
                .ProjectTo<BatchDto>(
                    _context.Batches
                        .Include("QualityVision.QualityVisionProperties.QualityProperty")
                        .Include("Material")
                        .Include("Tests.QualityProperty")
                        .Where(q => q.Id == request.Id),
                    null
                )
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
