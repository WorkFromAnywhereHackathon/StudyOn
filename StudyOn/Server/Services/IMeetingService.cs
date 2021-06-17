using StudyOn.Server.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyOn.Server.Services
{
    public interface IMeetingService
    {
        Task<List<Meeting>> GetTodayAsync(Guid eventId);
        Task<Meeting> GetNextMeetingAsync(Guid eventId);
        Task<List<Meeting>> GetAsync(Guid eventId);
        Task AddDays(Guid eventId, int days);
    }
}