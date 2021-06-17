using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using StudyOn.Server.Data;
using StudyOn.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Services
{
    public class ExpertService : IExpertService
    {
        private readonly EducationContext _context;
        private readonly IMapper _mapper;

        public ExpertService(EducationContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<List<ExpertDto>> GetAsync(Guid eventId)
        {
            return _context.Experts
                .Where(x => x.Events.Any(x => x.EventId == eventId))
                .ProjectToType<ExpertDto>(_mapper.Config)
                .ToListAsync();
        }

        public Task<ExpertDto> GetbyIdAsync(Guid expertId)
        {
            return _context.Experts
                .ProjectToType<ExpertDto>(_mapper.Config)
                .FirstOrDefaultAsync(x => x.Id == expertId);
        }
    }
}
