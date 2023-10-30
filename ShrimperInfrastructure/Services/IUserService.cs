using ShrimperInfrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperInfrastructure.Services
{
    public interface IUserService
    {
        UserDto Get(string email);
        void Register(string email, string username, string password);
    }
}
