using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DocsReports.Models;

namespace DocsReports.Pages.ReportsPages
{
    public class CreateModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public CreateModel(DocsReports.Models.DocsReportsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EmployeeReceipt"] = new SelectList(_context.Employees, "Id", "Id");
        ViewData["EmployeeSend"] = new SelectList(_context.Employees, "Id", "Id");
        ViewData["ReportCategoryId"] = new SelectList(_context.ReportCategories, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Reports Reports { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reports.Add(Reports);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
