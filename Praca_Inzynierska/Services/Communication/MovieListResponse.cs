using Praca_Inzynierska.DTO;
using Praca_Inzynierska.DTO.ReturnDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Praca_Inzynierska.Models;

namespace Praca_Inzynierska.Services.Communication
{
    public class MovieListResponse : Response
    {
        public MovieListReturnDto MovieList { get; }

        private MovieListResponse(bool success, Dictionary<string, string[]> message, MovieListReturnDto movieList)
            : base(success, message)
        {
            MovieList = movieList;
        }

        public MovieListResponse(MovieListReturnDto movieList)
            : this(true, new Dictionary<string, string[]>(), movieList)
        {
        }

        public MovieListResponse(Dictionary<string, string[]> message)
            : this(false, message, null)
        {
        }
    }
}
