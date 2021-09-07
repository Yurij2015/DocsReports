using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocsReports.Models
{
    public partial class Positions
    {
        public Positions()
        {
            Employees = new HashSet<Employees>();
        }

        public int Id { get; set; }
        [Display(Name = "Название")]

        public string Title { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
