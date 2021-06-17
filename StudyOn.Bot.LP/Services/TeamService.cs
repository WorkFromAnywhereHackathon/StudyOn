using Flurl.Http;
using StudyOn.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Bot.Services
{
    public class TeamService : ITeamService
    {
        string baseAddress;
        string eventId;


        public TeamService(string address, string eventId)
        {
            this.baseAddress = address;
            this.eventId = eventId;
        }

        public Task<List<TeamDto>> GetAsync()
        {
            var address = $"{baseAddress}/api/events/{eventId}/teams";
            return address.GetJsonAsync<List<TeamDto>>();
        }

        public Task<TeamDto> GetByIdAsync(Guid teamId)
        {
            var address = $"{baseAddress}/api/events/{eventId}/teams/{teamId}";
            return address.GetJsonAsync<TeamDto>();
        }
    }
}
