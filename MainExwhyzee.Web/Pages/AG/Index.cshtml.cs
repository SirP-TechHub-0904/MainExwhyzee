using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MainExwhyzee.Domain.Data;
using MainExwhyzee.Domain.Models;

namespace MainExwhyzee.Web.Pages.AG
{
    public class IndexModel : PageModel
    {
        private readonly MainExwhyzee.Domain.Data.ApplicationDbContext _context;

        public IndexModel(MainExwhyzee.Domain.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Agsmis> Agsmis { get;set; }

        public async Task<IActionResult> OnGetAsync(string? code)
        {

            string xcode = "54321";
            if(code == null)
            {
                TempData["nocode"] = "nocode";
                return Page();
            }
            if (code == xcode) {
                TempData["access"] = "access";
                Agsmis = await _context.Agsmiss.ToListAsync();
                return Page();
            }

            TempData["noaccess"] = "noaccess";
            TempData["nocode"] = "nocode";
            return Page();
        }
    }
}
