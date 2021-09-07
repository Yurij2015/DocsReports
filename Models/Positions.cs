using System;
using System.Collections.Generic;

namespace DocsReports.Models
{
    public partial class Positions
    {
        public Positions()
        {
            Employees = new HashSet<Employees>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
