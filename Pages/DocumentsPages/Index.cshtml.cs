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
    public class IndexModel : PageModel
    {
        private readonly DocsReports.Models.DocsReportsContext _context;

        public IndexModel(DocsReports.Models.DocsReportsContext context)
        {
            _context = context;
        }

        public IList<Documents> Documents { get;set; }

        public async Task OnGetAsync()
        {
            Documents = await _context.Documents
                .Include(d => d.DocCategory)
                .Include(d => d.EmployeeSendNavigation)
                .Include(d => d.EployeeSentNavigation).ToListAsync();
        }
    }
}
