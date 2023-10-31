using ShrimperCore.Domain;
using ShrimperInfrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperInfrastructure.Services
{
    public interface IJwtProvider
    {
        JwtDto GenerateJwt(User user);
    }
}
