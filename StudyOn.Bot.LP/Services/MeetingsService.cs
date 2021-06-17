using StudyOn.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;


namespace StudyOn.Bot.Services
{
    public class MeetingsService : IMeetingService
    {
        string baseAddress;
        string eventId;

        public MeetingsService(string address, string eventId)
        {
            this.baseAddress = address;
            this.eventId = eventId;
        }        

        public Task<List<MeetingDto>> GetTodayAsync()
        {          
            var address = $"{baseAddress}/api/events/{eventId}/meetings/today";
            return address.GetJsonAsync<List<MeetingDto>>();
        }

        public Task<MeetingDto> GetNextAsync()
        {          
            var address = $"{baseAddress}/api/events/{eventId}/meetings/next";
            return address.GetJsonAsync<MeetingDto>();
        }

        public Task<List<MeetingDto>> GetAsync()
        {            
            var address = $"{baseAddress}/api/events/{eventId}/meetings";
            return address.GetJsonAsync<List<MeetingDto>>();
        }
    }
}
