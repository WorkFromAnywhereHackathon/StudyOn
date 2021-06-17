using StudyOn.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyOn.Server.Services
{
    public interface IExpertService
    {
        Task<List<ExpertDto>> GetAsync(Guid eventId);
        Task<ExpertDto> GetbyIdAsync(Guid expertId);
    }
}