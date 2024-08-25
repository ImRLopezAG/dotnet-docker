namespace web_api;
using service;
using Microsoft.AspNetCore.Mvc;

public static class StudentRouter
{
  public static RouteGroupBuilder MapStudentRoutes(this RouteGroupBuilder router)
  {
    var userRouter = router.MapGroup("/students");
    userRouter.WithTags("Students");
    userRouter.MapGet("", (IStudentService service) => service.GetAll())
              .WithName("GetAllStudents")
              .WithDescription("Get all students")
              .WithSummary("Get all students")
              .WithOpenApi(opt => opt);
    userRouter.MapGet("/{id}", (IStudentService service, Guid id) => service.GetById(id))
              .WithName("GetUserById")
              .WithDescription("Get user by id")
              .WithSummary("Get user by id")
              .WithOpenApi(opt => opt);
    userRouter.MapPost("", (IStudentService service, [FromBody] StudentSaveDto student) => service.Save(student))
              .WithName("AddUser")
              .WithDescription("Add user")
              .WithSummary("Add user")
              .WithOpenApi(opt => opt);
    userRouter.MapPut("/{id}", (IStudentService service, [FromBody] StudentSaveDto student, [FromRoute] Guid id) => service.Save(student, id))
              .WithName("UpdateUser")
              .WithDescription("Update user")
              .WithSummary("Update user")
              .WithOpenApi(opt => opt);
    return router;
  }
}
