using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passanger.Infrastucture.Services;
using Passanger.Infrastucture.DTO;
using Passanger.Infrastucture.Commands.Users;
using Passanger.Infrastucture.Commands;

namespace Passagner.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICommandDispatcher _commandDispatcher;

        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher)
        {
            _userService = userService;
            _commandDispatcher = commandDispatcher;
        }

        // GET
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if(user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        // POST
        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody]CreateUser command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Created($"user/{command.Email}", new object());
        }
    }
}
