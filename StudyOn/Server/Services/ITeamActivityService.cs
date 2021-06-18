using StudyOn.Server.Entities;
using StudyOn.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyOn.Server.Services
{
    public interface ITeamActivityService
    {
        Task<TeamActivity> AddAsync(AddTeamActivityModel model);
        Task<List<TeamActivityDto>> GetAsync(Guid teamId);
    }
}