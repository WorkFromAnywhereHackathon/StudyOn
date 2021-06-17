using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyOn.Server.Services;
using StudyOn.Shared;

namespace StudyOn.Server.Controllers
{
    [Route("api/events/{eventId}/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService teamService;

        public TeamsController(ITeamService teamService)
        {
            this.teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
        }

        [HttpPost]
        public async Task<ActionResult> Get(Guid eventId, [FromBody] TeamDto model)
        {
            model.EventId = eventId;
            var team = await teamService.AddAsync(model);
            return Ok(team);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Guid eventId, [FromBody] TeamDto model)
        {
            model.EventId = eventId;            
            var team = await teamService.UpdateAsync(model);
            return Ok(team);
        }

        [HttpGet]
        public async Task<ActionResult> Get(Guid eventId)
        {
            var teams = await teamService.GetAsync(eventId);
            return Ok(teams);
        }

        [HttpGet("{teamId}")]
        public async Task<ActionResult> GetById(Guid teamId)
        {
            var team = await teamService.GetByIdAsync(teamId);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }
    }
}
