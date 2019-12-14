using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Praca_Inzynierska.Models;
using Praca_Inzynierska.Persistence;

namespace Praca_Inzynierska
{
    public class IndexModel : PageModel
    {
        private readonly Praca_Inzynierska.Persistence.AppDbContext _context;

        public IndexModel(Praca_Inzynierska.Persistence.AppDbContext context)
        {
            _context = context;
        }

        public IList<Actor> Actor { get;set; }

        public async Task OnGetAsync()
        {
            Actor = await _context.Actors.ToListAsync();
        }
    }
}
