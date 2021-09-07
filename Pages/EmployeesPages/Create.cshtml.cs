using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DocsReports.Models;

namespace DocsReports.Pages.EmployeesPages
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
        ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Id");
        ViewData["PostionId"] = new SelectList(_context.Positions, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Employees Employees { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employees);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
