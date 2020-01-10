using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Praca_Inzynierska.DTO;
using Praca_Inzynierska.Models;
using Praca_Inzynierska.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Praca_Inzynierska.DTO.ReturnDto;

namespace Praca_Inzynierska.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
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
        [ProducesResponseType(typeof(Comment), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult AddComment([FromBody] CommentSaveDto commentSave)
        {
            var result = _commentService.AddComment(commentSave);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Comment);
        }
        [ProducesResponseType(typeof(CommentListReturnDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [HttpGet("getcomment/{id}")]
        public IActionResult GetCommentForMovie(int id)
        {
            var result = _commentService.GetCommentForMovie(id);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Comments);
        }
    }
}
