namespace domain;

public class StudentEntity : BaseEntity<Guid>
{
  public string Name { get; set; } = default!;
  public string Username { get; set; } = default!;
  public string Email { get; set; } = default!;
  public string Password { get; set; } = default!;
  public int CourseId { get; set; }
  public CourseEntity Course { get; set; } = default!;
  public ICollection<SubmissionEntity> Submissions { get; set; } = [];
  public ICollection<GradeEntity> Grades { get; set; } = [];
  public ICollection<AssignmentEntity> Assignments { get; set; } = [];
}
