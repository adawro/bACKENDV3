using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska.DTO.ReturnDto
{
    public class MovieReturnForList
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int ReleaseDate { get; set; }
        public string WrittenBy { get; set; }
        public string DirectionBy { get; set; }

    }
}
