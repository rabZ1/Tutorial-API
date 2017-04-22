using Microsoft.AspNetCore.Mvc;
using Passanger.Infrastucture.Commands;
using Passanger.Infrastucture.Commands.Users;
using Passanger.Infrastucture.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passanger.Api.Controllers
{
    public class AcccountController : ApiControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public AcccountController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        // PUT
        [HttpPut("password")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}
