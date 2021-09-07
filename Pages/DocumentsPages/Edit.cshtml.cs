using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DocsReports.Models;

namespace DocsReports.Pages.DocumentsPages
{
    public class EditModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public EditModel(DocsReports.Models.DocsReportsContext context)
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
           ViewData["DocCategoryId"] = new SelectList(_context.DocCategories, "Id", "Id");
           ViewData["EmployeeSend"] = new SelectList(_context.Employees, "Id", "Id");
           ViewData["EployeeSent"] = new SelectList(_context.Employees, "Id", "Id");
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

            _context.Attach(Documents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentsExists(Documents.Id))
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

        private bool DocumentsExists(int id)
        {
            return _context.Documents.Any(e => e.Id == id);
        }
    }
}
