using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using Praca_Inzynierska.Persistence;
using Praca_Inzynierska.Models;
using Praca_Inzynierska.DTO.Validators;
using Praca_Inzynierska.Services;
using Praca_Inzynierska.Services.Interfaces;

namespace Praca_Inzynierska.Extensions
{
    public static class StartupExtensions
    {
        // TODO: jesli juz by bylo gdzies na serwerze, ograniczyc odpowiednio dostep
        public static void AddCorsPolicy(this IServiceCollection services, string policyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(policyName, builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials());
            });
        }


        // TODO: jesli juz by bylo gdzies na serwerze, zastanawic sie nad poprawa
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                //options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, // validate the server that created this token
                    ValidateAudience = false, // ensure that the recipient of the token is authorized to receive it 
                    ValidateLifetime = false, // check that the token is not expired and that the signing key of the issuer is valid
                    ValidateIssuerSigningKey = true, // verify that the key used to sign the incoming token is part of a list of trusted keys
                    ValidIssuer = config["JwtIssuer"],
                    ValidAudience = config["JwtIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtKey"])),
                    //RequireSignedTokens = true
                    //RequireExpirationTime = true,
                    //ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
        }
        public static void AddSqlServerContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Praca_Inzynierska")));
        }
        public static void AddCustomMvc(this IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                // ponizsza metoda zmienia podstawowy format zwracany w przypadku bledu 400
                // z ValidationProblemDetails (v2.2 .net core) do SerializableError (v2.1)
                // wiecej informacji: https://docs.microsoft.com/pl-pl/aspnet/core/web-api/index?view=aspnetcore-2.2#automatic-http-400-responses
                // a rozwiazanie stad: https://stackoverflow.com/questions/51145243/how-do-i-customize-asp-net-core-model-binding-errors
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = actionContext => new BadRequestObjectResult(actionContext.ModelState);
                })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterAccountDtoValidator>());

        }
        
        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<UserAccount, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        }
        public static void AddSwaggerGenerator(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Praca_Inzynierska", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                options.AddFluentValidationRules();

            });
        }

        public static void AddServicesLayerDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            //services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IMovieService, MovieService>();
        }
    }
}
