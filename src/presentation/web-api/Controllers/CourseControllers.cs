using Microsoft.AspNetCore.Mvc;
using service;

namespace web_api;

public class CourseControllers(ICourseService service) : ICourseController
{


  public IResult GetAll()
  {
    var (courses, success, message) = service.GetAll();

    if (!success) return Results.NotFound("Courses Not Found");

    return Results.Ok(courses);
  }

  public async Task<IResult> GetById([FromRoute] int id)
  {
    var (courses, success, message) = await service.GetById(id);

    if (!success) return Results.NotFound("Courses Not Found");

    return Results.Ok(courses);
  }

  public async Task<IResult> Save([FromBody] CourseSaveDto course, [FromRoute] int id)
  {
    var (courses, success, message) = await service.Save(course, id);

    if (!success) return Results.BadRequest(message);
  
    return Results.Created<CourseDto>("", courses);
  }
  public async Task<IResult> Delete([FromRoute] int id)
  {
    await service.Delete(id);

    return Results.Ok("Done");
  }
}
