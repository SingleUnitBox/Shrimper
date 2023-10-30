using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShrimperCore.Enums;

namespace ShrimperCore.Domain
{
    public class Tank
    {
        public Guid Id { get; set; }
        public int Volume { get; protected set; }
        public WaterType WaterType { get; protected set; }
        public float CelciusTemperature { get; set; }
        public IEnumerable<Shrimp> Shrimps { get; set; }
    }
}
