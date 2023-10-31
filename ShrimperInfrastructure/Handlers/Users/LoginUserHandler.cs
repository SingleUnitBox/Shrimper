using AutoMapper;
using ShrimperCore.Domain;
using ShrimperInfrastructure.Commands;
using ShrimperInfrastructure.Commands.Users;
using ShrimperInfrastructure.Dto;
using ShrimperInfrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperInfrastructure.Handlers.Users
{
    public class LoginUserHandler : ICommandHandler<LoginUser>
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IJwtProvider _jwtProvider;
        private readonly IMapper _mapper;

        public LoginUserHandler(IUserService userService,
            ITokenService tokenService,
            IJwtProvider jwtProvider,
            IMapper mapper)
        {
            _userService = userService;
            _tokenService = tokenService;
            _jwtProvider = jwtProvider;
            _mapper = mapper;
        }

        public async Task HandleAsync(LoginUser command)
        {
            await _userService.LoginAsync(command.Email, command.Password);
            var user = _mapper.Map<User>(_userService.Get(command.Email));
            var jwt = _jwtProvider.GenerateJwt(user);
            jwt.TokenId = command.TokenId;
            _tokenService.Add(jwt);
        }
    }
}
