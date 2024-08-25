﻿namespace service;

public record class GradeDto
{
  public Guid Id { get; init; }
  public Guid StudentId { get; set; }
  public int CourseId { get; set; }
  public int Grade { get; set; }
  public string Comment { get; set; } = default!;
  public DateOnly GradedDate { get; set; }
  public int AssignmentId { get; set; }
  public StudentSaveDto Student { get; set; } = default!;
  public AssignmentSaveDto Assignment { get; set; } = default!;
}

public record class GradeSaveDto
{
  public Guid StudentId { get; set; }
  public int AssignmentId { get; set; }
  public int Grade { get; set; }
  public string Comment { get; set; } = default!;
  public DateOnly GradedDate { get; set; }
}