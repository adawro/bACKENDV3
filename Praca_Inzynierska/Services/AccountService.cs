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

namespace Praca_Inzynierska.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly string _userEmail;
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

            _userEmail = httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;
        }

        public async Task<AccountResponse> RegisterAccountAsync(RegisterAccountDto model)
        {
            var errors = new Dictionary<string, string[]>();
            var user = _mapper.Map<RegisterAccountDto, UserAccount>(model);

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors) errors.Add(error.Code, new[] { error.Description });

                return new AccountResponse(errors);
            }
            _context.SaveChanges();

            var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
            var response = new JwtTokenDto
            {
                Token = GenerateJwtToken(model.Email, appUser)
            };

            return new AccountResponse(response);
        }
        private string GenerateJwtToken(string email, UserAccount user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Name),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.Surname)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
