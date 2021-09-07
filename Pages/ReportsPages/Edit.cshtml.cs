using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DocsReports.Models;

namespace DocsReports.Pages.ReportsPages
{
    public class EditModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public EditModel(DocsReports.Models.DocsReportsContext context)
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
           ViewData["EmployeeReceipt"] = new SelectList(_context.Employees, "Id", "Id");
           ViewData["EmployeeSend"] = new SelectList(_context.Employees, "Id", "Id");
           ViewData["ReportCategoryId"] = new SelectList(_context.ReportCategories, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Reports).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportsExists(Reports.Id))
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

        private bool ReportsExists(int id)
        {
            return _context.Reports.Any(e => e.Id == id);
        }
    }
}
