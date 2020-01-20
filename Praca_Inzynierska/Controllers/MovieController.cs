using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Praca_Inzynierska.DTO.ReturnDto;
using Praca_Inzynierska.Services.Interfaces;
using Praca_Inzynierska.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Praca_Inzynierska.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        /// <summary>
        ///     Dodaje nowy film do bazy
        /// </summary>
        /// <returns>Dane utworzonego filmu</returns>
        /// <response code="200">
        ///     Szczegolowe dane utworzonego filmu
        /// </response>
        /// <response code="400">
        ///     Jesli sa jakies bledy w formularzu lub z jakiegos powodu
        ///     nie udalo sie dodac ogloszenia (np. bledny uzytkownik, nie istniejaca kategoria)
        /// </response>
        [ProducesResponseType(typeof(MovieReturnDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult AddMovie([FromForm] MovieSaveDto movie)
        {
            var result = _movieService.AddMovie(movie);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Movie);
        }


        [ProducesResponseType(typeof(MovieReturnDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("edit/{id}")]
        public IActionResult EditMovie(int id, [FromBody]MovieEditDto movie)
        {
            var result = _movieService.EditMovie(id, movie);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Movie);
        }

        [ProducesResponseType(typeof(MovieListReturnDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [HttpGet("find/{movieTitle}")]
        public IActionResult FindMovie(string movieTitle)
        {
            var result = _movieService.FindMovie(movieTitle);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.MovieList);
        }
        [ProducesResponseType(typeof(MovieReturnDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [HttpGet("details/{id}")]
        public IActionResult MovieDetails(int id)
        {
            var result = _movieService.MovieDetails(id);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Movie);
        }
    }
}
