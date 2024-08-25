using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using service;

namespace web_api;

public interface ICourseController
{
  IResult GetAll();
  Task<IResult> GetById([FromRoute] int id);
  Task<IResult> Save([FromBody] CourseSaveDto course, [Optional][FromRoute] int id);
  Task<IResult> Delete([FromRoute] int id);
}
