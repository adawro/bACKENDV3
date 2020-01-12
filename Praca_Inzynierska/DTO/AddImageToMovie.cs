using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska.DTO
{
    public class AddImageToMovie
    {
        public int MovieId { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
