using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska.DTO
{
    public class ActorEditDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Born { get; set; }
        public string CV { get; set; }
        public string CityBorn { get; set; }
        public string CountryBorn { get; set; }
    }
}
