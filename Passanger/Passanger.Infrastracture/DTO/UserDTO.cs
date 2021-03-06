﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Passanger.Infrastucture.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
