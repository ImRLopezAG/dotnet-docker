using domain;
using service;

namespace application;

public class StudentService(IStudentRepository _repository): GenService<StudentEntity, StudentDto, StudentSaveDto, Guid>(_repository), IStudentService
{

}
