using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetAllBatchesQueryHandler : IRequestHandler<GetAllBatchesQuery, List<BatchDto>>
    {
        private readonly Database.DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetAllBatchesQueryHandler(Database.DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BatchDto>> Handle(
            GetAllBatchesQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _mapper
                .ProjectTo<BatchDto>(
                    _context.Batches
                        .Include("QualityVision.QualityProperties.QualityProperty")
                        .Include("Material")
                        .Include("Tests.QualityProperty"),
                    null
                )
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
