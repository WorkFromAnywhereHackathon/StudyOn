using StudyOn.Server.Entities;
using StudyOn.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyOn.Server.Services
{
    public interface IEventService
    {
        Task<EducationEvent> AddAsync(AddEventModel model);
        Task<List<EventDto>> GetAsync(Guid customerId);
        Task DeleteAsync(Guid eventId);
        Task<EventDto> GetByIdAsync(Guid eventId);
        Task<EducationEvent> UpdateAsync(AddEventModel model);
    }
}