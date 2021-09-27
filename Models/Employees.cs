using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocsReports.Models
{
    public partial class Employees
    {
        public Employees()
        {
            DocumentsEmployeeSendNavigation = new HashSet<Documents>();
            DocumentsEployeeSentNavigation = new HashSet<Documents>();
            ReportsEmployeeReceiptNavigation = new HashSet<Reports>();
            ReportsEmployeeSendNavigation = new HashSet<Reports>();
        }

        public int Id { get; set; }
        [Display(Name = "ФИО сотрудника")]

        public string FullName { get; set; }
        [Display(Name = "Номер телефона")]

        public string Phone { get; set; }
        [Display(Name = "Электронный адрес")]

        public string Email { get; set; }

        public int? BranchId { get; set; }

        public int? PostionId { get; set; }

        [Display(Name = "Отдел")]

        public virtual Branches Branch { get; set; }
        [Display(Name = "Должность")]

        public virtual Positions Postion { get; set; }
        [Display(Name = "Отправитель документа")]
        public virtual ICollection<Documents> DocumentsEmployeeSendNavigation { get; set; }
        [Display(Name = "Получатель документа")]
        public virtual ICollection<Documents> DocumentsEployeeSentNavigation { get; set; }
        [Display(Name = "Отчет для сотрудника")]
        public virtual ICollection<Reports> ReportsEmployeeReceiptNavigation { get; set; }
        [Display(Name = "Отчет отправил сотрудник")]
        public virtual ICollection<Reports> ReportsEmployeeSendNavigation { get; set; }
    }
}
