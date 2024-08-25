namespace domain;

public class BaseEntity<TId>
{
  public TId Id { get; set; } = default!;
  public DateOnly CreatedAt { get; set; }
  public DateOnly UpdatedAt { get; set; }
  public bool IsDeleted { get; set; }
  public DateOnly? DeletedAt { get; set; }
}
