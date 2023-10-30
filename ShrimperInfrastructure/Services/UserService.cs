using AutoMapper;
using ShrimperCore.Domain;
using ShrimperCore.Repositories;
using ShrimperInfrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperInfrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto Get(string email)
        {
            var user = _userRepository.GetByEmailAsync(email);
            return _mapper.Map<UserDto>(user);
        }

        public void Register(string email, string username, string password)
        {
            var user = _userRepository.GetByEmailAsync(email);
            if (user != null)
            {
                throw new Exception($"User with email {email} already exists.");
            }
            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, username, password, salt);
            _userRepository.CreateAsync(user);
        }
    }
}
