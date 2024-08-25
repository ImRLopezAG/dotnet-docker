namespace service;

public record class SubmissionDto
{
  public Guid Id { get; init; }
  public Guid StudentId { get; set; }
  public int AssignmentId { get; set; }
  public string Content { get; set; } = default!;
  public DateOnly SubmittedDate { get; set; }
  public StudentSaveDto Student { get; set; } = default!;
  public AssignmentSaveDto Assignment { get; set; } = default!;
}

public record class SubmissionSaveDto
{
  public Guid StudentId { get; set; }
  public int AssignmentId { get; set; }
  public string Content { get; set; } = default!;
  public DateOnly SubmittedDate { get; set; }
}