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
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET
        [HttpGet("{email}")]
        public async Task<UserDto> Get(string email)
        {
            return await _userService.GetAsync(email);
        }

        // POST
        [HttpPost("")]
        public async Task Create([FromBody]CreateUser request)
        {
            await _userService.RegisterAsync(request.Email, request.Password, request.Username);
        }
    }
}
