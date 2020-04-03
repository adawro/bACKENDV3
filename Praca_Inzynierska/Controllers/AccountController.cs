using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Praca_Inzynierska.DTO;
using Praca_Inzynierska.Services.Interfaces;
using Praca_Inzynierska.DTO.ReturnDto;

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

        [ProducesResponseType(typeof(JwtTokenDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("registerMod")]
        public async Task<IActionResult> RegisterMod([FromBody] RegisterAccountDto model)
        {
            var result = await _accountService.RegisterModAccountAsync(model);

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

        /// <summary>
        ///     Edytujemy istniejące konto Imie i nazwisko
        /// </summary>
        /// <returns>
        ///     Obiekt json z tokenem jwt
        ///     uzytkownika pobiermy po tokenie ktory jest tworzony przy rejestracji
        ///     po porawnej zmianie imienia i nazwiska jest tworzony nowy token
        ///     FIRSTNAME = IMIE
        ///     LASTNAME = NAZWIKO
        /// </returns>
        /// <response code="200">
        ///     JWT - jesli udalo sie zmienic imie lub nazwisko
        /// </response>
        /// <response code="400">Jesli sa jakies bledy w formularzu lub email nie istanije albo edytuje nie swoje konto </response>
        [ProducesResponseType(typeof(JwtTokenDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("edit/PersonalData")]
        public IActionResult EditAccount([FromBody] AccountEditNameSurnameDto model)
        {
            var result = _accountService.EditNameSurname(model);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Token);
        }

        [ProducesResponseType(typeof(JwtTokenDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("edit/changePassword")]
        public async Task<IActionResult> ChangePassword(AccountEditPasswordDto passwordDto)
        {
            var result = await _accountService.ChangePassword(passwordDto);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Token);
        }

        /// <summary>
        ///     Edytujemy istniejące konto Imie i nazwisko
        /// </summary>
        /// <returns>
        ///     Obiekt json z tokenem jwt
        ///     uzytkownika pobiermy po tokenie ktory jest tworzony przy rejestracji
        ///     po porawnej zmianie imienia i nazwiska jest tworzony nowy token
        ///     FIRSTNAME = IMIE
        ///     LASTNAME = NAZWIKO
        /// </returns>
        /// <response code="200">
        ///     JWT - jesli udalo sie zmienic imie lub nazwisko
        /// </response>
        /// <response code="400">Jesli sa jakies bledy w formularzu lub email nie istanije albo edytuje nie swoje konto </response>
        [ProducesResponseType(typeof(JwtTokenDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("edit/UserName")]
        public IActionResult EditUserName([FromBody] AccountUserNameEditDto model)
        {
            var result = _accountService.EditUserName(model);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Token);
        }

        /// <summary>
        ///     Zmiana email zalogowanego uzytkownika
        /// </summary>
        /// <returns>
        ///     Obiekt json z tokenem jwt
        ///     uzytkownika pobiermy po tokenie ktory jest tworzony przy rejestracji
        ///     po porawnej zmianie emila jest tworzony nowy token
        ///     PASSWORD  - STARE HASLO
        ///     email - nowy emial
        /// </returns>
        /// <response code="200">
        ///     JWT - jesli udalo sie zmienic emial
        /// </response>
        /// <response code="400">Jesli sa jakies bledy w formularzu lub email nie istanije albo edytuje nie swoje konto </response>
        [ProducesResponseType(typeof(JwtTokenDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("EditEmail")]
        public async Task<IActionResult> EditAccountEmail([FromBody] AccountEditEmailDto emailDto)
        {
            var result = await _accountService.EditEmail(emailDto);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Token);
        }
        [ProducesResponseType(typeof(JwtTokenDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), 400)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("FindMe")]
        public IActionResult ReturnMe()
        {
            var result = _accountService.ReturnMe();

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.User);
        }
    }
}
