using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetAllMaterialsQueryHandler
        : IRequestHandler<GetAllMaterialsQuery, List<MaterialDto>>
    {
        private readonly Database.DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetAllMaterialsQueryHandler(Database.DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MaterialDto>> Handle(
            GetAllMaterialsQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _mapper
                .ProjectTo<MaterialDto>(_context.Materials, null)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
