using domain;
using service;

namespace persistence;

public class GradeRepository(EmpContext _context) : GenRepository<GradeEntity, Guid>(_context), IGradeRepository
{

}
