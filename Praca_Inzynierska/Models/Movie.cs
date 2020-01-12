using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public string DirectionBy { get; set; }
        public string WrittenBy { get; set; }
        public string Country { get; set; }
        public int BoxOffice { get; set; }
        public IList<MovieToActors> Actors { get; set; }
        public float Ratio { get; set; }
        public IList<ImageMovie> Images { get; set; }

    }
}
