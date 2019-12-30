using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Praca_Inzynierska.DTO;
using Praca_Inzynierska.Models;
using Praca_Inzynierska.Persistence;
using Praca_Inzynierska.Services.Communication;
using Praca_Inzynierska.Services.Interfaces;
using Praca_Inzynierska.DTO.ReturnDto;

namespace Praca_Inzynierska.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly string _userName;
        private readonly UserManager<UserAccount> _userManager;

        public AccountService(SignInManager<UserAccount> signInManager,
            UserManager<UserAccount> userManager,
            IMapper mapper,
            IConfiguration configuration,
            AppDbContext context,
            IHttpContextAccessor httpContext)      
                        
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            _context = context;

            _userName = httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;
        }

        public async Task<AccountResponse> RegisterAccountAsync(RegisterAccountDto model)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            UserAccount userr = _context.Users.FirstOrDefault(e => e.Email == model.Email);

            if(userr != null)
            {
                errors.Add("Emial", new[] { "Email jets juz zajety" });
                return new AccountResponse(errors);
            }

            userr = _context.Users.FirstOrDefault(e => e.NormalizedUserName == model.UserName.ToUpper());
            if (userr != null)
            {
                errors.Add("Useranme", new[] { "Nazwa uzytkoniwka jets juz zajeta" });
                return new AccountResponse(errors);
            }

            UserAccount user = _mapper.Map<RegisterAccountDto, UserAccount>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            string rola = "moderator";

            user.Rola = rola;
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors) errors.Add(error.Code, new[] { error.Description });

                return new AccountResponse(errors);
            }

            _context.SaveChanges();

            UserAccount appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
            JwtTokenDto response = new JwtTokenDto
            {
                Token = GenerateJwtToken(model.UserName, appUser)
            };
            return new AccountResponse(response);
        }
        public async Task<AccountResponse> LoginAccountAsync(LoginAccountDto model)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (!result.Succeeded)
            {
                errors.Add("Konto", new[] { "Nie udalo sie zalogowac" });
                return new AccountResponse(errors);
            }

            UserAccount appUser = _userManager.Users.SingleOrDefault(r => r.UserName == model.UserName);
            JwtTokenDto response = new JwtTokenDto
            {
                Token = GenerateJwtToken(model.UserName, appUser)
            };

            return new AccountResponse(response);
        }
        private string GenerateJwtToken(string userName, UserAccount user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, user.Rola),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Name),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.Surname)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            JwtSecurityToken token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AccountResponse EditNameSurname(AccountEditNameSurnameDto model)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            UserAccount user = _context.UserAccounts.AsNoTracking().FirstOrDefault(u => u.UserName == _userName || u.Email == _userName);
            if (user == null)
            {
                errors.Add("User", new[] { "Podane konto nie istnieje" });
                return new AccountResponse(errors);
            }
            if (model.Name != null)
            {
                user.Name = model.Name;
            }
            else
                model.Name = user.Name;

            if (model.Surname != null)
            {
                user.Surname = model.Surname;
            }
            else
                model.Surname = user.Surname;

            try
            {
                _context.UserAccounts.Update(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                errors.Add("Wystąpił nieoczekiwany błąd", new[] { ex.Message });
                return new AccountResponse(errors);
            }

            JwtTokenDto response = new JwtTokenDto
            {
                Token = GenerateJwtToken(user.Email, user)
            };
            return new AccountResponse(response);
        }

        public AccountResponse EditUserName(AccountUserNameEditDto model)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            UserAccount user = _context.UserAccounts.AsNoTracking().FirstOrDefault(u => u.UserName == _userName);
            if (user == null)
            {
                errors.Add("User", new[] { "Podane konto nie istnieje" });
                return new AccountResponse(errors);
            }
            user.UserName = model.UserName;
            user.NormalizedUserName = model.UserName.ToUpper();

            try
            {
                _context.UserAccounts.Update(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                errors.Add("Wystąpił nieoczekiwany błąd", new[] { ex.Message });
                return new AccountResponse(errors);
            }

            var response = new JwtTokenDto
            {
                Token = GenerateJwtToken(user.Email, user)
            };
            return new AccountResponse(response);
        }

        public async Task<AccountResponse> ChangePassword(AccountEditPasswordDto passwordDto)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            UserAccount user = _context.UserAccounts.AsNoTracking().FirstOrDefault(u => u.UserName == _userName || u.Email == _userName);
            if (user == null)
            {
                errors.Add("User", new[] { "Podane konto nie istnieje" });
                return new AccountResponse(errors);
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, passwordDto.OldPassword, false);
            if (!signInResult.Succeeded)
            {
                errors.Add("Hasło", new[] { "Podałeś zle haslo" });
                return new AccountResponse(errors);
            }

            var changeResult = await _userManager.ChangePasswordAsync(await _userManager.FindByIdAsync(user.Id),
                                    passwordDto.OldPassword, passwordDto.NewPassword);

            if (!changeResult.Succeeded)
            {
                errors.Add("Hasło", new[] { changeResult.ToString() });
                return new AccountResponse(errors);
            }

            JwtTokenDto response = new JwtTokenDto
            {
                Token = GenerateJwtToken(user.Email, user)
            };
            return new AccountResponse(response);
        }
        public async Task<AccountResponse> EditEmail(AccountEditEmailDto emailDto)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();


            UserAccount user = _context.UserAccounts.AsNoTracking().FirstOrDefault(u => u.UserName == _userName);
            if (user == null)
            {
                errors.Add("User", new[] { "Podane konto nie istnieje" });
                return new AccountResponse(errors);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, emailDto.Password, false);
            if (!result.Succeeded)
            {
                errors.Add("Hasło", new[] { "Podałeś zle haslo" });
                return new AccountResponse(errors);
            }

            UserAccount doExistEmail = await _context.UserAccounts.AsNoTracking().FirstOrDefaultAsync(u => u.Email == emailDto.Email);
            if (doExistEmail != null)
            {
                errors.Add("Email", new[] { "Podałeś zajety Email" });
                return new AccountResponse(errors);
            }

            try
            {
                user.Email = emailDto.Email;
                user.NormalizedEmail = emailDto.Email.ToUpper();
                _context.UserAccounts.Update(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                errors.Add("Wystąpił nieoczekiwany błąd", new[] { ex.Message });
                return new AccountResponse(errors);
            }

            JwtTokenDto response = new JwtTokenDto
            {
                Token = GenerateJwtToken(user.Email, user)
            };

            return new AccountResponse(response);
        }

        public AccountReturnResponse ReturnMe()
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            UserAccount user = _context.Users.FirstOrDefault(u => u.UserName == _userName);
            if (user == null)
            {
                errors.Add("Konto", new[] { "Musiz sie zalogować" });
                return new AccountReturnResponse(errors);
            }

            var userReturn = _mapper.Map<UserAccount, AccountReturn>(user);

            return new AccountReturnResponse(userReturn);
        }

        public async Task<AccountResponse> RegisterModAccountAsync(RegisterAccountDto model)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            UserAccount userr = _context.Users.FirstOrDefault(e => e.Email == model.Email);

            if(userr.Rola !="admin")
            {
                errors.Add("Rola", new[] { "NIe masz tutaj dostępu" });
                return new AccountResponse(errors);
            }
            if (userr != null)
            {
                errors.Add("Emial", new[] { "Email jets juz zajety" });
                return new AccountResponse(errors);
            }

            userr = _context.Users.FirstOrDefault(e => e.NormalizedUserName == model.UserName.ToUpper());
            if (userr != null)
            {
                errors.Add("Useranme", new[] { "Nazwa uzytkoniwka jest juz zajeta" });
                return new AccountResponse(errors);
            }

            UserAccount user = _mapper.Map<RegisterAccountDto, UserAccount>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            string rola = "moderator";

            user.Rola = rola;
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors) errors.Add(error.Code, new[] { error.Description });

                return new AccountResponse(errors);
            }

            _context.SaveChanges();

            UserAccount appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
            JwtTokenDto response = new JwtTokenDto
            {
                Token = GenerateJwtToken(model.Email, appUser)
            };
            return new AccountResponse(response);
        }
    }
}
