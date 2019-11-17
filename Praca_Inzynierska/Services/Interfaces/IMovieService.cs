using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Praca_Inzynierska.Services.Communication;
using Praca_Inzynierska.DTO;

namespace Praca_Inzynierska.Services.Interfaces
{
   public interface IMovieService
    {
        MovieResponse AddMovie(MovieSaveDto movie);
        MovieListResponse FindMoviesForActor(int id);
    }
}
