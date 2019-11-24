using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Praca_Inzynierska.Services.Communication;
using Praca_Inzynierska.DTO;
using Praca_Inzynierska.DTO.ReturnDto;

namespace Praca_Inzynierska.Services.Interfaces
{
   public interface IMovieService
    {
        MovieResponse AddMovie(MovieSaveDto movie);
        MovieReturnForActor FindMoviesForActor(int id);
        MovieListResponse FindMovie(FindMovieDto movieTitle);
        MovieResponse MovieDetails(int id);
    }
}
