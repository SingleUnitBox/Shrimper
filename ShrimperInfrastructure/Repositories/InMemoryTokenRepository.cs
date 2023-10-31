using ShrimperCore.Domain;
using ShrimperCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperInfrastructure.Repositories
{
    public class InMemoryTokenRepository : ITokenRepository
    {
        private static ISet<Jwt> _tokens = new HashSet<Jwt>();
        public void Add(Jwt token)
        {
            _tokens.Add(token);
        }

        public Jwt GetById(Guid id)
            => _tokens.FirstOrDefault();
            //=> _tokens.SingleOrDefault(token => token.Id == id);
    }
}
