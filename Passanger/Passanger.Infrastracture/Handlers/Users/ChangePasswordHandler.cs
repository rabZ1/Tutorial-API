using Passanger.Infrastucture.Commands;
using Passanger.Infrastucture.Commands.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passanger.Infrastucture.Handlers.Users
{
    class ChangePasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        public async Task HandleAsync(ChangeUserPassword command)
        {
            if(command.NewPassword != null)
            {
                command.CurrentPassword = command.NewPassword;
            }

            await Task.CompletedTask;
        }
    }
}
