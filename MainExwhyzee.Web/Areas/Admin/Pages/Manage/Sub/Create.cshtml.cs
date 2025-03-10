﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MainExwhyzee.Domain.Data;
using MainExwhyzee.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MainExwhyzee.Web.Areas.Admin.Pages.Manage.Sub
{
    public class CreateModel : PageModel
    {
        private readonly MainExwhyzee.Domain.Data.ApplicationDbContext _context;

        public CreateModel(MainExwhyzee.Domain.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["WDAccountId"] = new SelectList(_context.WDAccounts, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public WDSubAccount SubAccount { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //  {
            //      return Page();
            //  }
            var check = await _context.SubAccounts.FirstOrDefaultAsync(x => x.MainUrl.ToUpper() == SubAccount.MainUrl);
            if (check != null)
            {
                if (check.TypeOfAccount == SubAccount.TypeOfAccount)
                {

                    ViewData["WDAccountId"] = new SelectList(_context.WDAccounts, "Id", "Name");
                    TempData["error"] = "Mail Url Already Existing";
                    return Page();
                }
            }
            SubAccount.Date = DateTime.UtcNow;
            SubAccount.DateCreated = DateTime.UtcNow;

            _context.SubAccounts.Add(SubAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
