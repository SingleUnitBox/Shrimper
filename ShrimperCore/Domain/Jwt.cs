using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperCore.Domain
{
    public class Jwt
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
    }
}
