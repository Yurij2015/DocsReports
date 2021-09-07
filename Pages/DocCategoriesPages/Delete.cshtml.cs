using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DocsReports.Models;

namespace DocsReports.Pages.DocCategoriesPages
{
    public class DeleteModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public DeleteModel(DocsReports.Models.DocsReportsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DocCategories DocCategories { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DocCategories = await _context.DocCategories.FirstOrDefaultAsync(m => m.Id == id);

            if (DocCategories == null)
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

            DocCategories = await _context.DocCategories.FindAsync(id);

            if (DocCategories != null)
            {
                _context.DocCategories.Remove(DocCategories);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
