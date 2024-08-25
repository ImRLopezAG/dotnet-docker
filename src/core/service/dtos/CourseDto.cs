namespace service;

public record class CourseDto
{
  public int Id { get; init; }
  public string Name { get; set; } = default!;
  public string Desc { get; set; } = default!;
  public Guid ProfessorId { get; set; }
  public StudentSaveDto Professor { get; set; } = default!;
  public List<StudentSaveDto> Students { get; set; } = [];
}

public record class CourseSaveDto
{
  public string Name { get; set; } = default!;
  public string Desc { get; set; } = default!;
  public Guid ProfessorId { get; set; }
}
