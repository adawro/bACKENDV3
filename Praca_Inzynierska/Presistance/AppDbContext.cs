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
        
        #region Role i testowy uzytkownik
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            const string testAccountId = "b01bex90-aa65-4af8-bd17-00bd9344e575";
            var hasher = new PasswordHasher<UserAccount>();
            
            builder.Entity<UserAccount>().HasData(new UserAccount
            {
                Id = testAccountId,
                UserName = "test@test.test",
                NormalizedUserName = "TEST@TEST.TEST",
                Email = "test@test.test",
                NormalizedEmail = "TEST@TEST.TEST",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "test123"),
                SecurityStamp = string.Empty,
                Name = "Konto",
                Surname = "Testowe",
                Rola = "TEST"
            });

            builder.Entity<UserAccount>().HasData(new UserAccount
            {
                UserName = "admin@admin.pl",
                NormalizedUserName = "ADMIN@ADMIN.PL",
                Email = "admin@admin.pl",
                NormalizedEmail = "ADMIN@ADMIN.PL",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "admin1234"),
                SecurityStamp = string.Empty,
                Name = "Admin",
                Surname = "Admin",
                Rola = "Admin"
            });
        }

        
        #endregion
    }
}


