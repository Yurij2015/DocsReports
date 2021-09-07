using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocsReports.Models
{
    public partial class Reports
    {
        public int Id { get; set; }
        [Display(Name = "Название")]

        public string Title { get; set; }
        [Display(Name = "Описание")]

        public string Description { get; set; }
        [Display(Name = "Дата добавления")]

        public DateTime? Dateadd { get; set; }
        [Display(Name = "Отправитель документа")]

        public int? EmployeeSend { get; set; }
        [Display(Name = "Получатель документа")]

        public int? EmployeeReceipt { get; set; }
        [Display(Name = "Количество страниц")]

        public int? PageCount { get; set; }
        [Display(Name = "Место хранения")]

        public int? ArchiveId { get; set; }
        [Display(Name = "")]

        public int? ReportCategoryId { get; set; }

        public virtual Employees EmployeeReceiptNavigation { get; set; }
        public virtual Employees EmployeeSendNavigation { get; set; }
        public virtual ReportCategories ReportCategory { get; set; }
    }
}
