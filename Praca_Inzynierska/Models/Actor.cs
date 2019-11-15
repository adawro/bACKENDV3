using System;
using System.Collections.Generic;

namespace Praca_Inzynierska.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Born { get; set; }
        public int Age { get; set; }
        public string CV { get; set; }
        public string CityBorn { get; set; }
        public string CountryBorn { get; set; }
        public string AccountCreate { get; set; }
        public string ActorName { get; set; }
        public string ActorSurname { get; set; }
    }
}

