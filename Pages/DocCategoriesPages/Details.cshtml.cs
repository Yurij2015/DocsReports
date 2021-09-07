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
    public class DetailsModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public DetailsModel(DocsReports.Models.DocsReportsContext context)
        {
            _context = context;
        }

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
    }
}
