using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DocsReports.Models;

namespace DocsReports.Pages.BranchesPages
{
    public class IndexModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public IndexModel(DocsReports.Models.DocsReportsContext context)
        {
            _context = context;
        }

        public IList<Branches> Branches { get;set; }

        public async Task OnGetAsync()
        {
            Branches = await _context.Branches.ToListAsync();
        }
    }
}
