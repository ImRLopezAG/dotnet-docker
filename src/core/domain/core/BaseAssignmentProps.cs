namespace domain;

public class BaseAssignmentProps: BaseEntity<Guid>
{
  public int AssignmentId { get; set; }
  public AssignmentEntity Assignment { get; set; } = default!;
}
