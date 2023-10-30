using ShrimperCore.Domain;
using ShrimperCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperInfrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User("user1@gmail.com", "user1", "password", "salt"),
            new User("user2@gmail.com", "user2", "password", "salt"),
        };
        public User GetByIdAsync(Guid id)
            => _users.SingleOrDefault(x => x.Id == id);
        public User GetByEmailAsync(string email)
            => _users.SingleOrDefault(x => x.Email == email);
        public IEnumerable<User> GetAllAsync()
            => _users;
        public void CreateAsync(User user)
        {
            _users.Add(user);
        }
        public void UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
        public void DeleteAsync(Guid id)
        {
            var user = GetByIdAsync(id);
            _users.Remove(user);
        }     
    }
}
