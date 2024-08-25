using domain;

namespace service;

public interface IStudentService : IGenService<StudentEntity, StudentDto, StudentSaveDto, Guid>
{

}
