using domain;
using service;

namespace persistence;

public class StudentRepository(EmpContext _context) : GenRepository<StudentEntity, Guid>(_context), IStudentRepository
{

}
