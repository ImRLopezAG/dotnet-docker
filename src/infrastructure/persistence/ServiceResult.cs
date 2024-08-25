using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using service;

namespace persistence;

public static class ServiceRegistration
{
  public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration config)
  {
    #region DbContext
    services.AddDbContext<EmpContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(EmpContext).Assembly.FullName)));
    #endregion

    #region Repositories
    services.AddScoped(typeof(IGenRepository<,>), typeof(GenRepository<,>));
    services.AddScoped<IStudentRepository, StudentRepository>();
    services.AddScoped<IProfessorRepository, ProfessorRepository>();
    services.AddScoped<IAssignmentRepository, AssignmentRepository>();
    services.AddScoped<ICourseRepository, CourseRepository>();
    services.AddScoped<IGradeRepository, GradeRepository>();
    services.AddScoped<ISubmissionRepository, SubmissionRepository>();
    #endregion
  }
}
