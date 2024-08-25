namespace domain;

public class SubmissionEntity : BaseAssignmentProps
{
  public Guid StudentId { get; set; }
  public string Content { get; set; } = default!;
  public DateOnly SubmittedDate { get; set; }
  public StudentEntity Student { get; set; } = default!;
}
