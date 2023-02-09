using AutoMapper;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MaterialsEvaluation.Shared.Application;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetOneQualityPropertyQueryHandler
        : IRequestHandler<GetOneQualityPropertyQuery, QualityPropertyDto>
    {
        private readonly Database.DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetOneQualityPropertyQueryHandler(Database.DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QualityPropertyDto> Handle(
            GetOneQualityPropertyQuery request,
            CancellationToken cancellationToken
        )
        {
            var dto = await _mapper
                .ProjectTo<QualityPropertyDto>(
                    _context.QualityProperties.Where(q => q.Id == request.Id),
                    null
                )
                .FirstOrDefaultAsync(cancellationToken);

            if (dto == null)
            {
                throw new NotFoundException("QualityProperty não encontrado!");
            }

            return dto;
        }
    }
}
