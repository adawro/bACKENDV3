using Praca_Inzynierska.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace Praca_Inzynierska.Persistence
{
    public class AppDbContext : IdentityDbContext<UserAccount>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Models.Type> Types { get;set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieToActors> MoviesToActor { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ImageMovie> MovieImages { get; set; }



        #region Role i testowy uzytkownik
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    //const string adminID = "b01bex90-aa65-4af8-bd17-00bd9344e789";
        //    //var hasher = new PasswordHasher<UserAccount>();
        //    //builder.Entity<UserAccount>().HasData(new UserAccount
        //    //{
        //    //    Id = adminID,
        //    //    UserName = "KontoAdmina",
        //    //    NormalizedUserName = "KONTOADMINA",
        //    //    Email = "admin@admin.pl",
        //    //    NormalizedEmail = "ADMIN@ADMIN.PL",
        //    //    EmailConfirmed = true,
        //    //    PasswordHash = hasher.HashPassword(null, "admin123"),
        //    //    SecurityStamp = string.Empty,
        //    //    Name = "Konto",
        //    //    Surname = "Admin",
        //    //    Rola = "admin"
        //    //});


        //    //    List<Models.Type> TyprList = new List<Models.Type>()
        //    //{
        //    //    new Models.Type { TypeId = 100, Name = "Akcja" },
        //    //    new Models.Type { TypeId = 101, Name = "Animacja" },
        //    //    new Models.Type { TypeId = 102, Name = "Dokumentalny" },
        //    //    new Models.Type { TypeId = 103, Name = "Dramat" },
        //    //    new Models.Type { TypeId = 104, Name = "Familijny" },
        //    //    new Models.Type { TypeId = 105, Name = "Fantasy" },
        //    //    new Models.Type { TypeId = 106, Name = "Horror" },
        //    //    new Models.Type { TypeId = 107, Name = "Komedia" },
        //    //    new Models.Type { TypeId = 108, Name = "Kryminał" },
        //    //    new Models.Type { TypeId = 109, Name = "Przygodowy" },
        //    //    new Models.Type { TypeId = 110, Name = "Sci-Fi" },
        //    //    new Models.Type { TypeId = 111, Name = "Romans" },
        //    //    new Models.Type { TypeId = 112, Name = "Anime" },
        //    //    new Models.Type { TypeId = 113, Name = "Melodramat" },
        //    //    new Models.Type { TypeId = 114, Name = "Bibliograficzny" }
        //    //};
        //}
        #endregion
    }
}


