using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DocsReports.Models;

namespace DocsReports.Pages.ReportCategoriesPages
{
    public class DeleteModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public DeleteModel(DocsReports.Models.DocsReportsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ReportCategories ReportCategories { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReportCategories = await _context.ReportCategories.FirstOrDefaultAsync(m => m.Id == id);

            if (ReportCategories == null)
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

            ReportCategories = await _context.ReportCategories.FindAsync(id);

            if (ReportCategories != null)
            {
                _context.ReportCategories.Remove(ReportCategories);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
