using Microsoft.AspNetCore.Mvc;
using StudyOn.Bot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace StudyOn.Bot.Controllers
{
   
    [Route("api/update")]
    public class UpdateController : Controller
    {
        private readonly IUpdateService _updateService;

        public UpdateController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {           
            await _updateService.EchoAsync(update);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("wazza");
        }
    }
}
