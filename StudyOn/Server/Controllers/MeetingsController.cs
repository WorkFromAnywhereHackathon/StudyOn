using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyOn.Server.Data;
using StudyOn.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Controllers
{
    [Route("api/events/{eventId}/meetings")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingService meetingService;

        public MeetingsController(IMeetingService meetingService)
        {
            this.meetingService = meetingService ?? throw new ArgumentNullException(nameof(meetingService));
        }

        [HttpGet("today")]
        public async Task<ActionResult> GetToday(Guid eventId)
        {
            var meetings = await meetingService.GetTodayAsync(eventId);
            return Ok(meetings);
        }

        [HttpGet("addDays")]
        public async Task<ActionResult> AddDays(Guid eventId)
        {
            await meetingService.AddDays(eventId, 28);
            return Ok();
        }

        [HttpGet("next")]
        public async Task<ActionResult> GetNext(Guid eventId)
        {
            var meeting = await meetingService.GetNextMeetingAsync(eventId);
            return Ok(meeting);
        }

        [HttpGet()]
        public async Task<ActionResult> Get(Guid eventId)
        {
            var meetings = await meetingService.GetAsync(eventId);
            return Ok(meetings);
        }
    }
}
