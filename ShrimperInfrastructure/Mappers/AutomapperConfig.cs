using AutoMapper;
using ShrimperCore.Domain;
using ShrimperInfrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperInfrastructure.Mappers
{
    public static class AutomapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>().ReverseMap();
                cfg.CreateMap<Jwt, JwtDto>().ReverseMap();
            })
            .CreateMapper();
    }
}
