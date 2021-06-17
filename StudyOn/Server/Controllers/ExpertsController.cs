using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyOn.Server.Services;

namespace StudyOn.Server.Controllers
{
    [Route("api/events/{eventId}/experts")]
    [ApiController]
    public class ExpertsController : ControllerBase
    {
        private readonly IExpertService _expertService;

        public ExpertsController(IExpertService expertService)
        {
            _expertService = expertService ?? throw new ArgumentNullException(nameof(expertService));
        }

        [HttpGet]
        public async Task<ActionResult> Get(Guid eventId)
        {
            var experts =await _expertService.GetAsync(eventId);
            return Ok(experts);
        }

        [HttpGet("{expertId}")]
        public async Task<ActionResult> GetById(Guid expertId)
        {
            var expert =await _expertService.GetbyIdAsync(expertId);
            if (expert==null)
            {
                return NotFound();
            }
            return Ok(expert);
        }
    }
}
;