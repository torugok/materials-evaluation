using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetAllMaterialBatchQueryHandler
        : IRequestHandler<GetAllMaterialBatchQuery, List<MaterialBatchDto>>
    {
        private readonly Database.DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetAllMaterialBatchQueryHandler(Database.DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MaterialBatchDto>> Handle(
            GetAllMaterialBatchQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _mapper
                .ProjectTo<MaterialBatchDto>(
                    _context.MaterialBatches
                        .Include("QualityVision.QualityVisionProperties.QualityProperty")
                        .Include("Material")
                        .Include("MaterialBatchTests.QualityProperty"),
                    null
                )
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
