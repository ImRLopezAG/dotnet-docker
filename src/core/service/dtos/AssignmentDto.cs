namespace service;

public record class AssignmentDto
{
  public int Id { get; init; }
  public string Title { get; set; } = default!;
  public string Desc { get; set; } = default!;
  public DateOnly DueDate { get; set; }
  public int CourseId { get; set; }
  public Guid StudentId { get; set; }
  public CourseSaveDto Course { get; set; } = default!;
  public ICollection<SubmissionSaveDto> Submissions { get; set; } = [];
  public ICollection<GradeSaveDto> Grades { get; set; } = [];
}

public record class AssignmentSaveDto
{
  public string Title { get; set; } = default!;
  public string Desc { get; set; } = default!;
  public DateOnly DueDate { get; set; }
  public int CourseId { get; set; }
  public Guid StudentId { get; set; }
}