using Praca_Inzynierska.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Praca_Inzynierska.Persistence
{
    public class AppDbContext : IdentityDbContext<UserAccount>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}

