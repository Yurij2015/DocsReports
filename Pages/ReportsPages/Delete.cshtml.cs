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
    public class DeleteModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public DeleteModel(DocsReports.Models.DocsReportsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reports Reports { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reports = await _context.Reports
                .Include(r => r.EmployeeReceiptNavigation)
                .Include(r => r.EmployeeSendNavigation)
                .Include(r => r.ReportCategory).FirstOrDefaultAsync(m => m.Id == id);

            if (Reports == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reports = await _context.Reports.FindAsync(id);

            if (Reports != null)
            {
                _context.Reports.Remove(Reports);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
