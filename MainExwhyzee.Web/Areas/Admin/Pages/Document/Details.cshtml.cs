using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MainExwhyzee.Domain.Data;
using MainExwhyzee.Domain.Models;

namespace MainExwhyzee.Web.Areas.Admin.Pages.Document
{
    public class DetailsModel : PageModel
    {
        private readonly MainExwhyzee.Domain.Data.ApplicationDbContext _context;

        public DetailsModel(MainExwhyzee.Domain.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Agsmis Agsmis { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Agsmiss == null)
            {
                return NotFound();
            }

            var agsmis = await _context.Agsmiss.FirstOrDefaultAsync(m => m.Id == id);
            if (agsmis == null)
            {
                return NotFound();
            }
            else 
            {
                Agsmis = agsmis;
            }
            return Page();
        }
    }
}
