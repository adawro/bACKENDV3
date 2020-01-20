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

    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }


        /// <summary>
        ///     Dodaje nowego aktora do bazy
        /// </summary>
        /// <returns>Dane utworzonego aktora</returns>
        /// <response code="200">
        ///     Szczegolowe dane utworzonego aktora (w tym autor)
        /// </response>
        /// <response code="400">
        ///     Jesli sa jakies bledy w formularzu lub z jakiegos powodu
        ///     nie udalo sie dodac ogloszenia (np. bledny uzytkownik)
        /// </response>
        [ProducesResponseType(typeof(ActorReturnDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult AddActor([FromForm] ActorSaveDto actorSave)
        {
            var result = _actorService.AddActor(actorSave);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Actor);
        }

        /// <summary>
        ///     Edytuje dane aktora w bazie
        /// </summary>
        /// <returns>Dane edytowanego aktora</returns>
        /// <response code="200">
        ///     Szczegolowe dane utworzonego aktora (w tym autor)
        /// </response>
        /// <response code="400">
        ///     Jesli sa jakies bledy w formularzu lub z jakiegos powodu
        ///     nie udalo sie dodac ogloszenia (np. bledny uzytkownik)
        /// </response>
        [ProducesResponseType(typeof(ActorReturnDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}")]
        public IActionResult EditActor(int id, [FromForm] ActorEditDto actorEdit)
        {
            var result = _actorService.EditActor(id, actorEdit);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Actor);
        }
        [ProducesResponseType(typeof(ActorListReturnDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [HttpGet("find/{actorName}")]
        public IActionResult FindActor(string actorName)    
        {
            var result = _actorService.FindActor(actorName);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.ActorList);
        }
        [ProducesResponseType(typeof(ActorReturnDetails), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [HttpGet("details/{id}")]
        public IActionResult ActorDetails(int id)
        {
            var result = _actorService.ActorDetails(id);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.ActorDetails);
        }
    }
}
