using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DocsReports.Models;

namespace DocsReports.Pages.EmployeesPages
{
    public class IndexModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public IndexModel(DocsReports.Models.DocsReportsContext context)
        {
            _context = context;
        }

        public IList<Employees> Employees { get;set; }

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees
                .Include(e => e.Branch)
                .Include(e => e.Postion).ToListAsync();
        }
    }
}
