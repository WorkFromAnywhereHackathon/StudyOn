using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyOn.Server.Services;
using StudyOn.Shared;

namespace StudyOn.Server.Controllers
{
    [Route("api/teams/{teamId}/activites")]
    [ApiController]
    public class TeamActivitiesController : ControllerBase
    {
        private readonly ITeamActivityService teamActivityService;

        public TeamActivitiesController(ITeamActivityService teamActivityService)
        {
            this.teamActivityService = teamActivityService ?? throw new ArgumentNullException(nameof(teamActivityService));
        }

        [HttpGet]
        public async Task<ActionResult> Get(Guid teamId)
        {
            var activities = await teamActivityService.GetAsync(teamId);
            return Ok(activities);
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddTeamActivityModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teamActivity = await teamActivityService.AddAsync(model);
            return Ok(teamActivity.Adapt<TeamActivityDto>());
        }
    }
}
