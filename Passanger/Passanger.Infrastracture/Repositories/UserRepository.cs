using System;
using System.Collections.Generic;
using Passanger.Core.Repositories;
using Passanger.Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Passanger.Infrastracture.Repositories
{
    public class UserRepository : IUserRepository
    {

        private static ISet<User> _users = new HashSet<User>
        {
            new User("user1@gmail.com", "secret", "aa", "user1"),
            new User("user2@gmail.com", "secret", "aa", "user2"),
            new User("user3@gmail.com", "secret", "aa", "user3")
        };

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<User> GetAsync(Guid id)
        => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email)
        {
            return await Task.FromResult(_users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}
