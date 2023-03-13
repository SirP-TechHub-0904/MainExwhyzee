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
    public class DeleteModel : PageModel
    {
        private readonly MainExwhyzee.Domain.Data.ApplicationDbContext _context;

        public DeleteModel(MainExwhyzee.Domain.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.SubAccounts == null)
            {
                return NotFound();
            }
            var subaccount = await _context.SubAccounts.FindAsync(id);

            if (subaccount != null)
            {
                SubAccount = subaccount;
                _context.SubAccounts.Remove(SubAccount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
