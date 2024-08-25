namespace web_api;
using application;
using persistence;

public static class ServiceRegistration
{
  public static void AddPresentationServices(this IServiceCollection services)
  {
    services.AddScoped<ICourseController, CourseControllers>();
  }
  public static void RegisterServices(this IServiceCollection services, IConfiguration config)
  {
    services.AddPersistenceInfrastructure(config);
    services.AddApplicationServices();
    services.AddPresentationServices();
    services.AddSwaggerGen();
  }

  public static RouteGroupBuilder UseApplicationRouting(this RouteGroupBuilder router, IServiceCollection services)
  {
    var provider = services.BuildServiceProvider();
    router.MapStudentRoutes()
                .MapCourseRoutes(provider.GetRequiredService<ICourseController>())
                .MapProfessorRoutes();

    return router;
  }
}
