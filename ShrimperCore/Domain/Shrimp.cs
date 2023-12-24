using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShrimperCore.Enums;

namespace ShrimperCore.Domain
{
    public class Shrimp
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Species Species { get; protected set; }
        
    }
}
