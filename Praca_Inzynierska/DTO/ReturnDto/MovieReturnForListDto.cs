using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska.DTO.ReturnDto
{
    public class MovieReturnForListDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ActorNameInMovie { get; set; }
    }
}
