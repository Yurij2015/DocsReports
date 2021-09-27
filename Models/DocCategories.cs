using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocsReports.Models
{
    public partial class DocCategories
    {
        public DocCategories()
        {
            Documents = new HashSet<Documents>();
        }

        public int Id { get; set; }
        [Display(Name = "Название")]

        public string Title { get; set; }
        [Display(Name = "Описание")]

        public string Description { get; set; }

        [Display(Name = "Документ")]
        public virtual ICollection<Documents> Documents { get; set; }
    }
}
