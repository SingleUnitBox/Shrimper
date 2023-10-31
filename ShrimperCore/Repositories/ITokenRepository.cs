using ShrimperCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperCore.Repositories
{
    public interface ITokenRepository
    {
        Jwt GetById(Guid id);
        void Add(Jwt token);
    }
}
