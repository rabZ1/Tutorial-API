﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Passanger.Infrastucture.Commands.Users
{
    public class CreateUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
