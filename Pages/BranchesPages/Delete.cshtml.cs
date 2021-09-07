using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DocsReports.Models;

namespace DocsReports.Pages.BranchesPages
{
    public class DeleteModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public DeleteModel(DocsReports.Models.DocsReportsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Branches Branches { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Branches = await _context.Branches.FirstOrDefaultAsync(m => m.Id == id);

            if (Branches == null)
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

            Branches = await _context.Branches.FindAsync(id);

            if (Branches != null)
            {
                _context.Branches.Remove(Branches);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
