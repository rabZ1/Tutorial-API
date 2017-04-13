using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passanger.Infrastucture.Services;
using Passanger.Infrastucture.DTO;

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

        // GET api/values/5
        [HttpGet("{email}")]
        public UserDto Get(string email)
        {
            return _userService.Get(email);
        }
    }
}
