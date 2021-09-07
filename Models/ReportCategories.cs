using System;
using System.Collections.Generic;

namespace DocsReports.Models
{
    public partial class ReportCategories
    {
        public ReportCategories()
        {
            Reports = new HashSet<Reports>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Reports> Reports { get; set; }
    }
}
