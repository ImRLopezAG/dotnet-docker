using domain;
using service;

namespace persistence;

public class SubmissionRepository(EmpContext _context) : GenRepository<SubmissionEntity, Guid>(_context), ISubmissionRepository
{

}
