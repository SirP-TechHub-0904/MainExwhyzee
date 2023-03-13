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
    public class IndexModel : PageModel
    {
        private readonly MainExwhyzee.Domain.Data.ApplicationDbContext _context;

        public IndexModel(MainExwhyzee.Domain.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AccountType> AccountType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AccountTypes != null)
            {
                AccountType = await _context.AccountTypes.ToListAsync();
            }
        }
    }
}
