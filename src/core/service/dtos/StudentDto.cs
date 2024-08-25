using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using domain;

namespace service;

public record class StudentDto
{
  public Guid Id { get; init; }

  public string Name { get; set; } = default!;
  public string Username { get; set; } = default!;
  public string Email { get; set; } = default!;
  public int CourseId { get; set; }
  public CourseSaveDto Course { get; set; } = default!;
}

public record class StudentSaveDto
{
  public string Name { get; set; } = default!;
  public string Username { get; set; } = default!;
  [EmailAddress(ErrorMessage = "Invalid email address")]
  public string Email { get; set; } = default!;
  [Required(ErrorMessage = "Password is required")]
  public string Password { get; set; } = default!;
  [Compare("Password", ErrorMessage = "Passwords do not match")]
  public string ConfirmPassword { get; set; } = default!;
  public int CourseId { get; set; }
}