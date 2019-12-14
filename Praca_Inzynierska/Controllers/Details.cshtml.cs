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
    public class DetailsModel : PageModel
    {
        private readonly Praca_Inzynierska.Persistence.AppDbContext _context;

        public DetailsModel(Praca_Inzynierska.Persistence.AppDbContext context)
        {
            _context = context;
        }

        public Actor Actor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actor = await _context.Actors.FirstOrDefaultAsync(m => m.Id == id);

            if (Actor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
