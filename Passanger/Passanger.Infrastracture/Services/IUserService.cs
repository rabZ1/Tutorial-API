using System;
using System.Collections.Generic;
using System.Text;
using Passanger.Infrastracture;
using Passanger.Infrastucture.DTO;
using System.Threading.Tasks;

namespace Passanger.Infrastucture.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string password, string username);
        Task<UserDto> GetAsync(string email);
    }
}
