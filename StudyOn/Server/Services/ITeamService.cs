using StudyOn.Server.Entities;
using StudyOn.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyOn.Server.Services
{
    public interface ITeamService
    {
        Task<Team> AddAsync(TeamDto model);
        Task<List<TeamDto>> GetAsync(Guid eventId);
        Task<TeamDto> GetByIdAsync(Guid teamId);
        Task<Team> UpdateAsync(TeamDto model);
    }
}