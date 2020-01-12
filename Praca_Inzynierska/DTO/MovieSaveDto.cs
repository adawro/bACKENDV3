using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Praca_Inzynierska.DTO
{
    public class MovieSaveDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Type { get; set; }
        public string DirectionBy { get; set; }
        public string WrittenBy { get; set; }
        public string Country { get; set; }
        public int BoxOffice { get; set; }
        public List<ActorAddToMovie> Actors { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
