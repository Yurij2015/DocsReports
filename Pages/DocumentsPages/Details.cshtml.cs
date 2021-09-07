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
    public class DetailsModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public DetailsModel(DocsReports.Models.DocsReportsContext context)
        {
            _context = context;
        }

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
    }
}
