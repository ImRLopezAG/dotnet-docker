using System.ComponentModel.DataAnnotations;
using domain;

namespace service;

public record class ProfessorDto
{
  public Guid Id { get; init; }

  public string Name { get; set; } = default!;
  public string Username { get; set; } = default!;
  public string Email { get; set; } = default!;
  public ICollection<CourseSaveDto> Courses { get; set; } = [];
}

public record class ProfessorSaveDto
{
  public string Name { get; set; } = default!;
  public string Username { get; set; } = default!;
  [EmailAddress(ErrorMessage = "Invalid email address")]
  public string Email { get; set; } = default!;
  [Required(ErrorMessage = "Password is required")]
  public string Password { get; set; } = default!;
  [Compare("Password", ErrorMessage = "Passwords do not match")]
  public string ConfirmPassword { get; set; } = default!;
}