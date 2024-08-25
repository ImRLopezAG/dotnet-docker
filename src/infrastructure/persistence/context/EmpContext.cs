using domain;
using Microsoft.EntityFrameworkCore;

namespace persistence;

public class EmpContext(DbContextOptions<EmpContext> options) : DbContext(options)
{

  DbSet<StudentEntity> Students { get; set; }
  DbSet<CourseEntity> Courses { get; set; }
  DbSet<AssignmentEntity> Assignments { get; set; }
  DbSet<SubmissionEntity> Submissions { get; set; }
  DbSet<GradeEntity> Grades { get; set; }
  DbSet<ProfessorEntity> Professors { get; set; }

  public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
  {
    foreach (var entry in ChangeTracker.Entries())
      switch (entry.State)
      {
        case EntityState.Added:
          entry.CurrentValues["CreatedAt"] = DateOnly.FromDateTime(DateTime.UtcNow);
          entry.CurrentValues["UpdatedAt"] = DateOnly.FromDateTime(DateTime.UtcNow);
          break;
        case EntityState.Modified:
          entry.CurrentValues["UpdatedAt"] = DateOnly.FromDateTime(DateTime.UtcNow);
          break;
      }

    return base.SaveChangesAsync(cancellationToken);
  }

  protected override void OnModelCreating(ModelBuilder opt)
  {
    opt.Entity<StudentEntity>(user =>
    {
      user.HasKey(u => u.Id);
      user.Property(u => u.Name).IsRequired();
      user.Property(u => u.Username).IsRequired();
      user.Property(u => u.Email).IsRequired();
      user.Property(u => u.Password).IsRequired();
      user.HasIndex(u => u.Username).IsUnique();
      user.HasIndex(u => u.Email).IsUnique();
      user.HasOne(u => u.Course).WithMany(c => c.Students).HasForeignKey(u => u.CourseId);
    });

    opt.Entity<ProfessorEntity>(professor =>
    {
      professor.HasKey(p => p.Id);
      professor.Property(p => p.Name).IsRequired();
      professor.Property(p => p.Username).IsRequired();
      professor.Property(p => p.Email).IsRequired();
      professor.Property(p => p.Password).IsRequired();
      professor.HasIndex(p => p.Username).IsUnique();
      professor.HasIndex(p => p.Email).IsUnique();
    });

    opt.Entity<CourseEntity>(course =>
    {
      course.HasKey(c => c.Id);
      course.Property(c => c.Name).IsRequired();
      course.Property(c => c.Desc).IsRequired();
      course.HasOne(c => c.Professor).WithMany(p => p.Courses).HasForeignKey(c => c.ProfessorId);
    });

    opt.Entity<AssignmentEntity>(assignment =>
    {
      assignment.HasKey(a => a.Id);
      assignment.Property(a => a.Title).IsRequired();
      assignment.Property(a => a.Desc).IsRequired();
      assignment.Property(a => a.DueDate).IsRequired();
      assignment.HasOne(a => a.Course).WithMany(c => c.Assignments).HasForeignKey(a => a.CourseId);
      assignment.HasOne(a => a.Student).WithMany(s => s.Assignments).HasForeignKey(a => a.StudentId);
    });

    opt.Entity<SubmissionEntity>(submission =>
    {
      submission.HasKey(s => s.Id);
      submission.Property(s => s.Content).IsRequired();
      submission.Property(s => s.SubmittedDate).IsRequired();
      submission.HasOne(s => s.Assignment).WithMany(a => a.Submissions).HasForeignKey(s => s.AssignmentId);
      submission.HasOne(s => s.Student).WithMany(s => s.Submissions).HasForeignKey(s => s.StudentId);
    });
  }
}
