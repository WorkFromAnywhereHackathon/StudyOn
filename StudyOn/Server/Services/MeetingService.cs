using Microsoft.EntityFrameworkCore;
using StudyOn.Server.Data;
using StudyOn.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly EducationContext _context;

        public MeetingService(EducationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //TODO add DTO
        public Task<List<Meeting>> GetTodayAsync(Guid eventId)
        {
            var today = DateTime.Today;
            return _context.Meetings
                .Where(x => x.EventId == eventId && x.StartTime.Date == today)
                .OrderBy(x => x.StartTime)
                .ToListAsync();
        }

        public Task<List<Meeting>> GetAsync(Guid eventId)
        {
            var today = DateTime.Today;
            return _context.Meetings
                .Where(x => x.EventId == eventId)
                .OrderBy(x => x.StartTime)
                .ToListAsync();
        }

        public Task<Meeting> GetNextMeetingAsync(Guid eventId)
        {
            var now = DateTime.Now;
            return _context.Meetings
                .Where(x => x.EventId == eventId && x.StartTime >= now)
                .OrderBy(x => x.StartTime)
                .FirstOrDefaultAsync();
        }

        public async Task AddDays(Guid eventId, int days)
        {
            var meetings = await _context.Meetings
                .Where(x => x.EventId == eventId)
                .OrderBy(x => x.StartTime)
                .ToListAsync();

            foreach (var meeting in meetings)
            {
                meeting.StartTime = meeting.StartTime.AddDays(days);
                meeting.EndTime = meeting.EndTime.AddDays(days);
            }

            await _context.SaveChangesAsync();
        }
    }
}
