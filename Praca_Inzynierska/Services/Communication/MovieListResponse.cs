using System.Collections.Generic;
using Praca_Inzynierska.DTO;
using Praca_Inzynierska.DTO.ReturnDto;

namespace Praca_Inzynierska.Services.Communication
{
    public class MovieListResponse : Response
    {
        public MovieReturnForActor MovieList { get; }

        private MovieListResponse(bool success, Dictionary<string, string[]> message, MovieReturnForActor movieList)
            : base(success, message)
        {
            MovieList = movieList;
        }

        public MovieListResponse(MovieReturnForActor movieList)
            : this(true, new Dictionary<string, string[]>(), movieList)
        {

        }

        public MovieListResponse(Dictionary<string, string[]> message)
            : this(false, message, null)
        {
        }
    }
}
