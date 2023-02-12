using AutoMapper;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MaterialsEvaluation.Shared.Application;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetOneMaterialQueryHandler : IRequestHandler<GetOneMaterialQuery, MaterialDto>
    {
        private readonly Database.DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetOneMaterialQueryHandler(Database.DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MaterialDto> Handle(
            GetOneMaterialQuery request,
            CancellationToken cancellationToken
        )
        {
            var dto = await _mapper
                .ProjectTo<MaterialDto>(_context.Materials.Where(q => q.Id == request.Id), null)
                .FirstOrDefaultAsync(cancellationToken);

            if (dto == null)
            {
                throw new NotFoundException("Material não encontrado!");
            }

            return dto;
        }
    }
}
