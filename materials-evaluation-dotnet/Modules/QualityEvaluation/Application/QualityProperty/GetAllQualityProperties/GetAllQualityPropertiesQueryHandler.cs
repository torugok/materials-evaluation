using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetAllQualityPropertiesQueryHandler
        : IRequestHandler<GetAllQualityPropertiesQuery, List<QualityPropertyDto>>
    {
        private readonly Database.DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetAllQualityPropertiesQueryHandler(Database.DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<QualityPropertyDto>> Handle(
            GetAllQualityPropertiesQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _mapper
                .ProjectTo<QualityPropertyDto>(_context.QualityProperties, null)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
