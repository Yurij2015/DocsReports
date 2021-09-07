using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DocsReports.Models;

namespace DocsReports.Pages.PositionPages
{
    public class DetailsModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public DetailsModel(DocsReports.Models.DocsReportsContext context)
        {
            _context = context;
        }

        public Positions Positions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Positions = await _context.Positions.FirstOrDefaultAsync(m => m.Id == id);

            if (Positions == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
