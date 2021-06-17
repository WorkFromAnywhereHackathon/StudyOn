using Flurl.Http;
using Microsoft.Extensions.Options;
using StudyOn.Bot.Options;
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

        public TeamService(IOptions<BotOptions> options)
        {
            baseAddress = options.Value.Address;
            eventId = options.Value.EventId;
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
