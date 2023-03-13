using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MainExwhyzee.Domain.Data;
using MainExwhyzee.Domain.Models;

namespace MainExwhyzee.Web.Areas.Admin.Pages.Manage.Sub
{
    public class DetailsModel : PageModel
    {
        private readonly MainExwhyzee.Domain.Data.ApplicationDbContext _context;

        public DetailsModel(MainExwhyzee.Domain.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public SubAccount SubAccount { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.SubAccounts == null)
            {
                return NotFound();
            }

            var subaccount = await _context.SubAccounts.FirstOrDefaultAsync(m => m.Id == id);
            if (subaccount == null)
            {
                return NotFound();
            }
            else 
            {
                SubAccount = subaccount;
            }
            return Page();
        }
    }
}
