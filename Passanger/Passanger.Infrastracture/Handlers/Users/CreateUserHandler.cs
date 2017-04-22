using Passanger.Infrastucture.Commands;
using Passanger.Infrastucture.Commands.Users;
using Passanger.Infrastucture.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passanger.Infrastucture.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(command.Email, command.Password, command.Username);
        }
    }
}
