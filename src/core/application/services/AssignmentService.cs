using domain;
using service;

namespace application;

public class AssignmentService(IAssignmentRepository _repository): GenService<AssignmentEntity, AssignmentDto, AssignmentSaveDto, int>(_repository), IAssignmentService
{

}
