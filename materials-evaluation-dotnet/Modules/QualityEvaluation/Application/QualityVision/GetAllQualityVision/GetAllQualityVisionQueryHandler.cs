using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetAllQualityVisionQueryHandler
        : IRequestHandler<GetAllQualityVisionQuery, List<QualityVisionDto>>
    {
        private readonly Database.DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetAllQualityVisionQueryHandler(Database.DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<QualityVisionDto>> Handle(
            GetAllQualityVisionQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _mapper
                .ProjectTo<QualityVisionDto>(
                    _context.QualityVisions.Include("QualityVisionProperties.QualityProperty"),
                    null
                )
                .ToListAsync(cancellationToken);
        }
    }
}
