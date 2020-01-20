using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Praca_Inzynierska.DTO
{
    public class ActorSaveDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Born { get; set; }
        public string CV { get; set; }
        public string CityBorn { get; set; }
        public string CountryBorn { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
