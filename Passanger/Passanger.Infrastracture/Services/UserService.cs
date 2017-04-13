using System;
using System.Collections.Generic;
using System.Text;
using Passanger.Core.Repositories;
using Passanger.Core.Domain;
using Passanger.Infrastucture.DTO;

namespace Passanger.Infrastucture.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto Get(string email)
        {
            var user = _userRepository.Get(email);
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                FullName = user.FullName,
                CreatedAt = DateTime.UtcNow
            };
        }

        public void Register(string email, string password, string username)
        {
            var user = _userRepository.Get(email);
            if(user != null)
            {
                throw new Exception($"Uzytkownik z kontem email '{email}' istnieje.");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, password, salt, username);

            _userRepository.Add(user);
        }
    }
}
