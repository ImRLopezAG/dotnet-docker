using domain;
using service;

namespace persistence;

public class AssignmentRepository(EmpContext _context) : GenRepository<AssignmentEntity, int>(_context), IAssignmentRepository
{

}
