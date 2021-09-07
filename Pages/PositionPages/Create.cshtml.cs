using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DocsReports.Models;

namespace DocsReports.Pages.PositionPages
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
            return Page();
        }

        [BindProperty]
        public Positions Positions { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Positions.Add(Positions);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
