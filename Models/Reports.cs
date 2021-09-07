using System;
using System.Collections.Generic;

namespace DocsReports.Models
{
    public partial class Reports
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Dateadd { get; set; }
        public int? EmployeeSend { get; set; }
        public int? EmployeeReceipt { get; set; }
        public int? PageCount { get; set; }
        public int? ArchiveId { get; set; }
        public int? ReportCategoryId { get; set; }

        public virtual Employees EmployeeReceiptNavigation { get; set; }
        public virtual Employees EmployeeSendNavigation { get; set; }
        public virtual ReportCategories ReportCategory { get; set; }
    }
}
