using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyOn.Server.Data;
using StudyOn.Server.Services;
using StudyOn.Shared;

namespace StudyOn.Server.Controllers
{
    [Route("api/customers/{customerId}/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddEventModel model)
        {
            var educationEvent = await _eventService.AddAsync(model);

            var response = await _eventService.GetAsync(educationEvent.Id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] AddEventModel model)
        {
            await _eventService.UpdateAsync(model);

            var eductaionEvent = await _eventService.GetAsync(model.Id);
            return Ok(eductaionEvent);
        }

        [HttpGet]
        public async Task<ActionResult> Get(Guid customerId)
        {
            var educationEvents = await _eventService.GetAsync(customerId);
            return Ok(educationEvents);
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult> GetById(Guid eventId)
        {
            var educationEvent = await _eventService.GetByIdAsync(eventId);
            return Ok(educationEvent);
        }

        [HttpDelete("{eventId}")]
        public async Task<ActionResult> Delete(Guid eventId)
        {
            await _eventService.DeleteAsync(eventId);
            return NoContent();
        }
    }
}
