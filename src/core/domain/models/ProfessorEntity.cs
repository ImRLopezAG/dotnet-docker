namespace domain;

public class ProfessorEntity: BaseEntity<Guid>
{
  public string Name { get; set; } = default!;
  public string Username { get; set; } = default!;
  public string Email { get; set; } = default!;
  public string Password { get; set; } = default!;
  public ICollection<CourseEntity> Courses { get; set; } = [];
}