using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DocsReports.Models;

namespace DocsReports.Pages.ReportsPages
{
    public class IndexModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public IndexModel(DocsReports.Models.DocsReportsContext context)
        {
            _context = context;
        }

        public IList<Reports> Reports { get;set; }

        public async Task OnGetAsync()
        {
            Reports = await _context.Reports
                .Include(r => r.EmployeeReceiptNavigation)
                .Include(r => r.EmployeeSendNavigation)
                .Include(r => r.ReportCategory).ToListAsync();
        }
    }
}
