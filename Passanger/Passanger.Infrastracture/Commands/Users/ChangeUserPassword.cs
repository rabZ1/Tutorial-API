using System;
using System.Collections.Generic;
using System.Text;

namespace Passanger.Infrastucture.Commands.Users
{
    public class ChangeUserPassword : ICommand
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
