using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperCore.Domain
{
    public class Shrimper
    {
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public IEnumerable<Tank> Tanks { get; protected set; }
    }
}
