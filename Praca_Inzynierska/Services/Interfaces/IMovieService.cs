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
        MovieResponse EditMovie(int id, MovieEditDto movie);
        MovieReturnForActor FindMoviesForActor(int id);
        MovieListResponse FindMovie(string movieTitle);
        MovieResponse MovieDetails(int id);
    }
}
