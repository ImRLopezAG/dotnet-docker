namespace web_api;
using service;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.InteropServices;

public static class CourseRouter
{
  public static RouteGroupBuilder MapCourseRoutes(this RouteGroupBuilder router, ICourseController controller)
  {
    var courseRouter = router.MapGroup("/courses");
    courseRouter.WithTags("Courses");
    courseRouter.MapGet("/name/{name}", ([Optional] string? name) =>
    {
      if (String.IsNullOrEmpty(name) || name == "{name}") return Results.BadRequest("No Name");
      if (name.StartsWith("An")) return Results.StatusCode(500);
      string full = $"Hi {name}";
      return Results.Ok(full);
    })
    .WithResponses(HttpStatusCode.BadRequest, res =>
      res.AddDescription("No Name")
    )
    .WithResponses(HttpStatusCode.InternalServerError, res =>
      res.AddDescription("The server Has failed")
    )
    .WithOpenApi(opt => opt);
    courseRouter.MapGet("", () => controller.GetAll())
                .WithName("GetAllCourses")
                .WithDescription("Get all courses")
                .WithSummary("Get all courses")
                .WithOpenApi(opt => opt);
    courseRouter.MapGet("/{id}", ([FromRoute] int id) => controller.GetById(id))
                .WithName("GetCourseById")
                .WithDescription("Get course by id")
                .WithSummary("Get course by id")
                .WithOpenApi(opt => opt);
    courseRouter.MapPost("", ([FromBody] CourseSaveDto course) => controller.Save(course))
                .WithName("AddCourse")
                .WithDescription("Add course")
                .WithSummary("Add course")
                .WithResponses(HttpStatusCode.Created, res =>
                  res.AddDescription("Created"))
                .WithOpenApi(opt => opt);
    courseRouter.MapPut("/{id}", ([FromBody] CourseSaveDto course, [FromRoute] int id) => controller.Save(course, id))
                .WithName("UpdateCourse")
                .WithDescription("Update course")
                .WithSummary("Update course")
                .WithOpenApi(opt => opt);
    courseRouter.MapDelete("/{id:int}", ([FromRoute] int id) => controller.Delete(id));
    return router;
  }
}
