using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DocsReports.Models;

namespace DocsReports.Pages.BranchesPages
{
    public class EditModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public EditModel(DocsReports.Models.DocsReportsContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Branches).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchesExists(Branches.Id))
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

        private bool BranchesExists(int id)
        {
            return _context.Branches.Any(e => e.Id == id);
        }
    }
}
