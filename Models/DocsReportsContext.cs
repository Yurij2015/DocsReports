using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DocsReports.Models
{
    public partial class DocsReportsContext : DbContext
    {
        public DocsReportsContext()
        {
        }

        public DocsReportsContext(DbContextOptions<DocsReportsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<DocCategories> DocCategories { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<ReportCategories> ReportCategories { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-92LJ1R0\\SQLEXPRESS;Database=DocsReports;Trusted_Connection=True;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branches>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripton)
                    .HasColumnName("descripton")
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DocCategories>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(250);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArchiveId)
                    .HasColumnName("archiveId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(150);

                entity.Property(e => e.DocCategoryId).HasColumnName("docCategoryId");

                entity.Property(e => e.EmployeeSend).HasColumnName("employeeSend");

                entity.Property(e => e.EployeeSent).HasColumnName("eployeeSent");

                entity.Property(e => e.PageCount).HasColumnName("pageCount");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(150);

                entity.HasOne(d => d.DocCategory)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.DocCategoryId)
                    .HasConstraintName("FK_Documents_DocCategories_id");

                entity.HasOne(d => d.EmployeeSendNavigation)
                    .WithMany(p => p.DocumentsEmployeeSendNavigation)
                    .HasForeignKey(d => d.EmployeeSend)
                    .HasConstraintName("FK_Documents_Employees_id");

                entity.HasOne(d => d.EployeeSentNavigation)
                    .WithMany(p => p.DocumentsEployeeSentNavigation)
                    .HasForeignKey(d => d.EployeeSent)
                    .HasConstraintName("FK_Documents_Employees_id_1");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BranchId).HasColumnName("branchId");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.FullName)
                    .HasColumnName("fullName")
                    .HasMaxLength(150);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.PostionId).HasColumnName("postionId");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_Employees_Branches_id");

                entity.HasOne(d => d.Postion)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PostionId)
                    .HasConstraintName("FK_Employees_positions_id");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.ToTable("positions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ReportCategories>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Reports>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArchiveId).HasColumnName("archiveId");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(150);

                entity.Property(e => e.EmployeeReceipt).HasColumnName("employeeReceipt");

                entity.Property(e => e.EmployeeSend).HasColumnName("employeeSend");

                entity.Property(e => e.PageCount).HasColumnName("pageCount");

                entity.Property(e => e.ReportCategoryId).HasColumnName("reportCategoryId");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(150);

                entity.HasOne(d => d.EmployeeReceiptNavigation)
                    .WithMany(p => p.ReportsEmployeeReceiptNavigation)
                    .HasForeignKey(d => d.EmployeeReceipt)
                    .HasConstraintName("FK_Reports_Employees_id_1");

                entity.HasOne(d => d.EmployeeSendNavigation)
                    .WithMany(p => p.ReportsEmployeeSendNavigation)
                    .HasForeignKey(d => d.EmployeeSend)
                    .HasConstraintName("FK_Reports_Employees_id");

                entity.HasOne(d => d.ReportCategory)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ReportCategoryId)
                    .HasConstraintName("FK_Reports_ReportCategories_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
