namespace domain;

public class GradeEntity : BaseAssignmentProps
{
  public Guid StudentId { get; set; }
  public int CourseId { get; set; }
  public int Grade { get; set; }
  public string Comment { get; set; } = default!;
  public DateOnly GradedDate { get; set; }
  public StudentEntity Student { get; set; } = default!;
  public CourseEntity Course { get; set; } = default!;
}
