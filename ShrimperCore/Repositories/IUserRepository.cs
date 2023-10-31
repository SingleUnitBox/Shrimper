using ShrimperCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperCore.Repositories
{
    public interface IUserRepository : IRepository
    {
        User GetByIdAsync(Guid id);
        User GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        void CreateAsync(User user);
        void UpdateAsync(User user);
        void DeleteAsync(Guid id);

    }
}
