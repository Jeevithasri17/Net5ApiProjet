using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Kanini.Service
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<BooksUpdated> BooksUpdateds { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Department1> Departments1 { get; set; }
        public virtual DbSet<EmpTest> EmpTests { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee1> Employees1 { get; set; }
        public virtual DbSet<EmployeeDepartmentMapping> EmployeeDepartmentMappings { get; set; }
        public virtual DbSet<EmployeeDepartmentMapping1> EmployeeDepartmentMappings1 { get; set; }
        public virtual DbSet<EmployeeTbl> EmployeeTbls { get; set; }
        public virtual DbSet<EmployeeUpdateTbl> EmployeeUpdateTbls { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<ErrorLog1> ErrorLogs1 { get; set; }
        public virtual DbSet<Folder> Folders { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KANINI-LTP-478\\SQLSERVER2019;Database=EmployeeDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Authors", "Book");

                entity.Property(e => e.AuthorName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Books", "Book");

                entity.Property(e => e.BookTitle)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.AuthorId });

                entity.ToTable("BookAuthors", "Book");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_BookAuthors_Authors");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_BookAuthors_Books");
            });

            modelBuilder.Entity<BooksUpdated>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__BooksUpd__3DE0C20756BA6550");

                entity.ToTable("BooksUpdated", "Book");

                entity.Property(e => e.BookTitle)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department1>(entity =>
            {
                entity.ToTable("Department", "EmployeeDB");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EmpTest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EmpTest");

                entity.Property(e => e.Dept)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.Id, "Employee_Id");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee1>(entity =>
            {
                entity.ToTable("Employee", "EmployeeDB");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<EmployeeDepartmentMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EmployeeDepartmentMapping");

                entity.HasIndex(e => e.EmpId, "index_EmployeeId");

                entity.HasOne(d => d.Dept)
                    .WithMany()
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK__EmployeeD__DeptI__4222D4EF");

                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__EmployeeD__EmpId__412EB0B6");
            });

            modelBuilder.Entity<EmployeeDepartmentMapping1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EmployeeDepartmentMapping", "EmployeeDB");

                entity.HasOne(d => d.Dept)
                    .WithMany()
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("fk_DEPTID");

                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("fk_EMPID");
            });

            modelBuilder.Entity<EmployeeTbl>(entity =>
            {
                entity.ToTable("EmployeeTbl", "EmployeeDB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<EmployeeUpdateTbl>(entity =>
            {
                entity.ToTable("EmployeeUpdateTbl", "EmployeeDB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.ToTable("ErrorLog", "EmployeeDB");

                entity.Property(e => e.ErrorMessage).IsRequired();

                entity.Property(e => e.ErrorTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ErrorLog1>(entity =>
            {
                entity.ToTable("ErrorLog", "Error");

                entity.Property(e => e.ErrorMessage).IsRequired();

                entity.Property(e => e.ErrorTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.ToTable("Folders", "EmployeeDB");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.ToTable("ProductDetails", "Product");

                entity.Property(e => e.Product).HasMaxLength(50);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sales", "EmployeeDB");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SaleAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("sale_amount");

                entity.Property(e => e.SaleDate)
                    .HasColumnType("date")
                    .HasColumnName("sale_date");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("salesperson");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
