using System;
using System.Collections.Generic;
using Passanger.Core.Repositories;
using Passanger.Core.Domain;
using System.Linq;

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

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id)
        => _users.Single(x => x.Id == id);

        public User Get(string email)
        {
            return _users.Single(x => x.Email == email.ToLowerInvariant());
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
        }
    }
}
