using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperInfrastructure.Dto
{
    public class JwtDto
    {
        public Guid TokenId { get; set; }
        public string Token { get; set; }
    }
}
