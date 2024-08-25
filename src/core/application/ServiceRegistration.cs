using Microsoft.Extensions.DependencyInjection;
using service;

namespace application;

public static class ServiceRegistration
{
  public static void AddApplicationServices(this IServiceCollection services)
  {

    services.AddScoped(typeof(IGenService<,,,>), typeof(GenService<,,,>));
    services.AddScoped<IStudentService, StudentService>();
    services.AddScoped<IProfessorService, ProfessorService>();
    services.AddScoped<ICourseService, CourseService>();
    services.AddScoped<IAssignmentService, AssignmentService>();
    services.AddScoped<ISubmissionService, SubmissionService>();
    services.AddScoped<IGradeService, GradeService>();
  }
}