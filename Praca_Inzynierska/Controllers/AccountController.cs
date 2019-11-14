using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Praca_Inzynierska.DTO;
using Praca_Inzynierska.Services.Interfaces;


namespace Praca_Inzynierska.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        ///     Tworzy nowe konto.
        /// </summary>
        /// <returns>Obiekt json z tokenem jwt</returns>
        /// <response code="200">
        ///     JWT - jesli udalo sie zalozyc konto
        /// </response>
        /// <response code="400">Jesli sa jakies bledy w formularzu lub email zajety</response>
        [ProducesResponseType(typeof(JwtTokenDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccountDto model)
        {
            var result = await _accountService.RegisterAccountAsync(model);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Token);
        }
        /// <summary>
        ///     Potwierdza dane logowania uzytkownika i zwraca json web token.
        /// </summary>
        /// <returns>Obiekt json z tokenem jwt</returns>
        /// <response code="200">
        ///     JWT - jesli uzytkownik zostal potwierdzony
        /// </response>
        /// <response code="400">Jesli sa jakies bledy w formularzu lub nie udalo sie zalogowac</response>
        [ProducesResponseType(typeof(JwtTokenDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginAccountDto model)
        {
            var result = await _accountService.LoginAccountAsync(model);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Token);
        }
    }
}
