using domain;
using service;

namespace persistence;

public class ProfessorRepository(EmpContext _context) : GenRepository<ProfessorEntity, Guid>(_context), IProfessorRepository
{

}
