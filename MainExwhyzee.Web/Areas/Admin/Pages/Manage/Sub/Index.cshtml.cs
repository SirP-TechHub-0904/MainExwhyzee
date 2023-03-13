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
    public class IndexModel : PageModel
    {
        private readonly MainExwhyzee.Domain.Data.ApplicationDbContext _context;

        public IndexModel(MainExwhyzee.Domain.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SubAccount> SubAccount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SubAccounts != null)
            {
                SubAccount = await _context.SubAccounts
                .Include(s => s.AccountType).ToListAsync();
            }
        }
    }
}
