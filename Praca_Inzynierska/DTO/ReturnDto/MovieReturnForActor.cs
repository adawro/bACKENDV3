using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska.DTO.ReturnDto
{
    public class MovieReturnForActor
    {
        public int MovieId { get; set; }
        public List<string> Titles { get; set; }
    }
}

