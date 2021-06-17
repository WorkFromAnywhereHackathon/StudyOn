using StudyOn.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyOn.Bot.Services
{
    public interface ITeamService
    {
        Task<List<TeamDto>> GetAsync();
        Task<TeamDto> GetByIdAsync(Guid teamId);
    }
}