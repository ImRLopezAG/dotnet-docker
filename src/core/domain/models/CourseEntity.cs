namespace domain;

public class CourseEntity : BaseEntity<int>
{
  public string Name { get; set; } = default!;
  public string Desc { get; set; } = default!;
  public Guid ProfessorId { get; set; }
  public ProfessorEntity Professor { get; set; } = default!;
  public ICollection<StudentEntity> Students { get; set; } = [];
  public ICollection<AssignmentEntity> Assignments { get; set; } = [];
  public ICollection<GradeEntity> Grades { get; set; } = [];
}
