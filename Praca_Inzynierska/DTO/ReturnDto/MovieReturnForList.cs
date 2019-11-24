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
        public DateTime ReleaseDate { get; set; }
    }
}
