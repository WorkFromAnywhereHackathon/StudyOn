using StudyOn.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyOn.Bot.Services
{
    public interface IMeetingService
    {
        Task<List<MeetingDto>> GetTodayAsync();
        Task<MeetingDto> GetNextAsync();
        Task<List<MeetingDto>> GetAsync();
    }
}