using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passanger.Infrastucture.Services;
using Passanger.Infrastucture.DTO;
using Passanger.Infrastucture.Commands.Users;

namespace Passagner.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
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
        public async Task<IActionResult> Create([FromBody]CreateUser request)
        {
            await _userService.RegisterAsync(request.Email, request.Password, request.Username);

            return Created($"user/{request.Email}", new object());
        }
    }
}
