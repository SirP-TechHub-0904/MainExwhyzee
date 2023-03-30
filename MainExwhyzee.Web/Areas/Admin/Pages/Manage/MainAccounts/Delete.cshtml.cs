using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MainExwhyzee.Domain.Data;
using MainExwhyzee.Domain.Models;

namespace MainExwhyzee.Web.Areas.Admin.Pages.Manage.MainAccounts
{
    public class DeleteModel : PageModel
    {
        private readonly MainExwhyzee.Domain.Data.ApplicationDbContext _context;

        public DeleteModel(MainExwhyzee.Domain.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public WDAccount AccountType { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.WDAccounts == null)
            {
                return NotFound();
            }

            var accounttype = await _context.WDAccounts.FirstOrDefaultAsync(m => m.Id == id);

            if (accounttype == null)
            {
                return NotFound();
            }
            else 
            {
                AccountType = accounttype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.WDAccounts == null)
            {
                return NotFound();
            }
            var accounttype = await _context.WDAccounts.FindAsync(id);

            if (accounttype != null)
            {
                AccountType = accounttype;
                _context.WDAccounts.Remove(AccountType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
