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
    public class ExpertService : IExpertService
    {
        string baseAddress;
        string eventId;

        public ExpertService(IOptions<BotOptions> options)
        {
            baseAddress = options.Value.Address;
            eventId = options.Value.EventId;
        }

        public Task<List<ExpertDto>> GetAsync()
        {
            var address = $"{baseAddress}/api/events/{eventId}/experts";
            return address.GetJsonAsync<List<ExpertDto>>();
        }

        public Task<ExpertDto> GetByIdAsync(Guid teamId)
        {
            var address = $"{baseAddress}/api/events/{eventId}/experts/{teamId}";
            return address.GetJsonAsync<ExpertDto>();
        }
    }
}
