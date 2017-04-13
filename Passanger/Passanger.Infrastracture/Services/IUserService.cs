using System;
using System.Collections.Generic;
using System.Text;
using Passanger.Infrastracture;
using Passanger.Infrastucture.DTO;

namespace Passanger.Infrastucture.Services
{
    public interface IUserService
    {
        void Register(string email, string password, string username);
        UserDto Get(string email);
    }
}
