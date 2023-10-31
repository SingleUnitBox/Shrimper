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
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IMapper _mapper;

        public TokenService(ITokenRepository tokenRepository,
            IMapper mapper)
        {
            _tokenRepository = tokenRepository;
            _mapper = mapper;
        }
        public void Add(JwtDto jwt)
        {
            var token = _mapper.Map<Jwt>(jwt);
            _tokenRepository.Add(token);
        }

        public JwtDto Get(Guid id)
        {
            var token = _tokenRepository.GetById(id);
            return _mapper.Map<JwtDto>(token);
        }
    }
}
