namespace web_api;
using service;
using Microsoft.AspNetCore.Mvc;

public static class ProfessorRouter
{
  public static RouteGroupBuilder MapProfessorRoutes(this RouteGroupBuilder router)
  {
    var professorRouter = router.MapGroup("/professors");
    professorRouter.WithTags("Professors");
    professorRouter.MapGet("", (IProfessorService service) => service.GetAll())
                  .WithName("GetAllProfessors")
                  .WithDescription("Get all professors")
                  .WithSummary("Get all professors")
                  .WithOpenApi(opt => opt);
    professorRouter.MapGet("/{id}", (IProfessorService service, Guid id) => service.GetById(id))
                  .WithName("GetProfessorById")
                  .WithDescription("Get professor by id")
                  .WithSummary("Get professor by id")
                  .WithOpenApi(opt => opt);
    professorRouter.MapPost("", (IProfessorService service, [FromBody] ProfessorSaveDto professor) => service.Save(professor))
                  .WithName("AddProfessor")
                  .WithDescription("Add professor")
                  .WithSummary("Add professor")
                  .WithOpenApi(opt => opt);
    professorRouter.MapPut("/{id}", (IProfessorService service, [FromBody] ProfessorSaveDto professor, [FromRoute] Guid id) => service.Save(professor, id))
                  .WithName("UpdateProfessor")
                  .WithDescription("Update professor")
                  .WithSummary("Update professor")
                  .WithOpenApi(opt => opt);
    return router;
  }
}
