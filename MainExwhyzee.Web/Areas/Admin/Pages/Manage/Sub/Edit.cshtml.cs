using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MainExwhyzee.Domain.Data;
using MainExwhyzee.Domain.Models;

namespace MainExwhyzee.Web.Areas.Admin.Pages.Manage.Sub
{
    public class EditModel : PageModel
    {
        private readonly MainExwhyzee.Domain.Data.ApplicationDbContext _context;

        public EditModel(MainExwhyzee.Domain.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WDSubAccount SubAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.SubAccounts == null)
            {
                return NotFound();
            }

            var subaccount =  await _context.SubAccounts.FirstOrDefaultAsync(m => m.Id == id);
            if (subaccount == null)
            {
                return NotFound();
            }
            SubAccount = subaccount;
           ViewData["AccountTypeId"] = new SelectList(_context.WDAccounts, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            var check = await _context.SubAccounts.FirstOrDefaultAsync(x => x.MainUrl.ToUpper() == SubAccount.MainUrl);
            if (check != null)
            {
                ViewData["WDAccountId"] = new SelectList(_context.WDAccounts, "Id", "Name");
                TempData["error"] = "Mail Url Already Existing";
                return Page();
            }
            _context.Attach(SubAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubAccountExists(SubAccount.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SubAccountExists(long id)
        {
          return _context.SubAccounts.Any(e => e.Id == id);
        }
    }
}
