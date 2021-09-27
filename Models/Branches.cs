using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocsReports.Models
{
    public partial class Branches
    {
        public Branches()
        {
            Employees = new HashSet<Employees>();
        }

        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Descripton { get; set; }

        [Display(Name = "Сотрудник")]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
