using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using StudyOn.Server.Data;
using StudyOn.Server.Entities;
using StudyOn.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Services
{
    public class TeamActivityService : ITeamActivityService
    {
        private readonly EducationContext context;
        private readonly IMapper mapper;

        public TeamActivityService(EducationContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TeamActivity> AddAsync(AddTeamActivityModel model)
        {
            var activity = model.Adapt<TeamActivity>();
            context.Activities.Add(activity);
            await context.SaveChangesAsync();
            return activity;
        }

        public Task<List<TeamActivityDto>> GetAsync(Guid teamId)
        {

            return context.Activities
                 .Where(x => x.TeamId == teamId)
                 .ProjectToType<TeamActivityDto>(mapper.Config)
                 .ToListAsync();
        }
    }
}
