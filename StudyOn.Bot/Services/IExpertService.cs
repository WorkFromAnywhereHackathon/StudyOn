using StudyOn.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyOn.Bot.Services
{
    public interface IExpertService
    {
        Task<List<ExpertDto>> GetAsync();
        Task<ExpertDto> GetByIdAsync(Guid teamId);
    }
}