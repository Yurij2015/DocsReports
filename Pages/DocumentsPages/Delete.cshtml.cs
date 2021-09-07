using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DocsReports.Models;

namespace DocsReports.Pages.DocumentsPages
{
    public class DeleteModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public DeleteModel(DocsReports.Models.DocsReportsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Documents Documents { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Documents = await _context.Documents
                .Include(d => d.DocCategory)
                .Include(d => d.EmployeeSendNavigation)
                .Include(d => d.EployeeSentNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Documents == null)
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

            Documents = await _context.Documents.FindAsync(id);

            if (Documents != null)
            {
                _context.Documents.Remove(Documents);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
