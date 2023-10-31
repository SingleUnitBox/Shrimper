using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperInfrastructure.Commands.Users
{
    public class LoginUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; } = "password";
        public Guid TokenId { get; set; }
    }
}
