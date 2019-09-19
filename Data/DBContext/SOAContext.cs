using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.DBContext
{
    public partial class SOAContext : DbContext
    {
        public SOAContext()
        {
        }

        public SOAContext(DbContextOptions<SOAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Exams> Exams { get; set; }
        public virtual DbSet<StudentCourses> StudentCourses { get; set; }
        public virtual DbSet<StudentExams> StudentExams { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=SOA;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>(entity =>
            {
                entity.Property(e => e.Content)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Exams>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentCourses>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId });

                entity.HasIndex(e => new { e.StudentId, e.CourseId })
                    .HasName("IX_UserCourses")
                    .IsUnique();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCourses_Courses");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCourses_Users");
            });

            modelBuilder.Entity<StudentExams>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.ExamId });

                entity.HasIndex(e => new { e.StudentId, e.ExamId })
                    .HasName("IX_UserExams")
                    .IsUnique();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.StudentExams)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserExams_Exams");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentExams)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserExams_Users");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });


            modelBuilder.Entity<Courses>()
                .HasData(new Courses() { Id = 1, Title = "Course1", Content = "Course Content" }, new Courses() { Id = 2, Title = "Course2", Content = "Course2 Content" }, new Courses() { Id = 3, Title = "Course3", Content = "Course3 Content" });
            modelBuilder.Entity<Exams>()
                .HasData(new Exams() { Id = 1, Title = "Exam1", Content = "Exam Content" }, new Exams() { Id = 2, Title = "Exam2", Content = "Exam2 Content" }, new Exams() { Id = 3, Title = "Exam3", Content = "Exam3 Content" });
            modelBuilder.Entity<Students>()
                .HasData(new Students() { Id = 1, FirstName = "User1", LastName = "User1" }, new Students() { Id = 2, FirstName = "User2", LastName = "User2"}, new Students() { Id = 3, FirstName = "User3", LastName = "User3" });
            modelBuilder.Entity<StudentCourses>()
                .HasData(new StudentCourses() { StudentId = 1, CourseId = 1 }, new StudentCourses() { StudentId = 1, CourseId = 2 }, new StudentCourses() { StudentId = 1, CourseId = 3 },
                    new StudentCourses() { StudentId = 2, CourseId = 1 }, new StudentCourses() { StudentId = 2, CourseId = 2 }, new StudentCourses() { StudentId = 3, CourseId = 3 });
            modelBuilder.Entity<StudentExams>()
                .HasData(new StudentExams() { StudentId = 1, ExamId = 1 }, new StudentExams() { StudentId = 1, ExamId = 2 }, new StudentExams() { StudentId = 1, ExamId = 3 },
                    new StudentExams() { StudentId = 2, ExamId = 1 }, new StudentExams() { StudentId = 2, ExamId = 2 }, new StudentExams() { StudentId = 3, ExamId = 3 });
        }
    }
}
