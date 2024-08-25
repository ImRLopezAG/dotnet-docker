namespace domain;

public class AssignmentEntity : BaseEntity<int>
{
  public string Title { get; set; } = default!;
  public string Desc { get; set; } = default!;
  public DateOnly DueDate { get; set; }
  public int CourseId { get; set; }
  public Guid StudentId { get; set; }
  public CourseEntity Course { get; set; } = default!;
  public StudentEntity Student { get; set; } = default!;
  public List<SubmissionEntity> Submissions { get; set; } = [];
  public List<GradeEntity> Grades { get; set; } = [];
}
