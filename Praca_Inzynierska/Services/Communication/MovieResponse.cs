using Praca_Inzynierska.DTO.ReturnDto;
using System.Collections.Generic;

namespace Praca_Inzynierska.Services.Communication
{
    public class MovieResponse : Response
    {
        public MovieReturnDto Movie { get; }

        private MovieResponse(bool success, Dictionary<string, string[]> message, MovieReturnDto movie)
            : base(success, message)
        {
            Movie = movie;
        }

        public MovieResponse(MovieReturnDto movie)
            : this(true, new Dictionary<string, string[]>(), movie)
        {
        }

        public MovieResponse(Dictionary<string, string[]> message)
            : this(false, message, null)
        {
        }
    }
}
