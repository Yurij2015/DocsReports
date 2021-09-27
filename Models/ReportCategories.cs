using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocsReports.Models
{
    public partial class ReportCategories
    {
        public ReportCategories()
        {
            Reports = new HashSet<Reports>();
        }

        public int Id { get; set; }
        [Display(Name = "Название")]

        public string Title { get; set; }
        [Display(Name = "Описание")]

        public string Description { get; set; }
        [Display(Name = "Отчет")]

        public virtual ICollection<Reports> Reports { get; set; }
    }
}
