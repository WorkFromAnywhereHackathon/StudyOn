using Microsoft.EntityFrameworkCore;
using StudyOn.Server.Data;
using StudyOn.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using StudyOn.Shared;
using MapsterMapper;


namespace StudyOn.Server.Services
{
    public class TeamService : ITeamService
    {
        private readonly EducationContext _context;
        private readonly IMapper _mapper;

        public TeamService(EducationContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Team> AddAsync(TeamDto model)
        {
            var team = model.Adapt<Team>();
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public Task<TeamDto> GetByIdAsync(Guid teamId)
        {
            return _context.Teams
                .ProjectToType<TeamDto>(_mapper.Config)
               .FirstOrDefaultAsync(x => x.Id == teamId);
        }

        public Task<List<TeamDto>> GetAsync(Guid eventId)
        {
            return _context.Teams
               .Where(x => x.EventId == eventId)
                .ProjectToType<TeamDto>(_mapper.Config)
               .ToListAsync();
        }

        public async Task<Team> UpdateAsync(TeamDto model)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == model.Id);
            model.Adapt(team);
            await _context.SaveChangesAsync();
            return team;
        }
    }
}
