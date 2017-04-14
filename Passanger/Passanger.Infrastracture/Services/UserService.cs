using System;
using System.Collections.Generic;
using System.Text;
using Passanger.Core.Repositories;
using Passanger.Core.Domain;
using Passanger.Infrastucture.DTO;
using AutoMapper;
using System.Threading.Tasks;

namespace Passanger.Infrastucture.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task RegisterAsync(string email, string password, string username)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception($"Uzytkownik z kontem email '{email}' istnieje.");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, password, salt, username);

            await _userRepository.AddAsync(user);
        }
    }
}
