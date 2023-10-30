using AutoMapper;
using ShrimperCore.Domain;
using ShrimperInfrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperInfrastructure.Mappings
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<User, UserDto>();
        }
    }
}
