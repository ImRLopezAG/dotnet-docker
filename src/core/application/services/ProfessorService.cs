using domain;
using service;

namespace application;

public class ProfessorService(IProfessorRepository _repository): GenService<ProfessorEntity, ProfessorDto, ProfessorSaveDto, Guid>(_repository), IProfessorService
{

}
