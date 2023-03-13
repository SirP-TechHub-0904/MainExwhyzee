﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MainExwhyzee.Domain.Data;
using MainExwhyzee.Domain.Models;

namespace MainExwhyzee.Web.Areas.Admin.Pages.Manage.MainAccounts
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
            return Page();
        }

        [BindProperty]
        public AccountType AccountType { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AccountTypes.Add(AccountType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
