using domain;
using service;

namespace application;

public class SubmissionService(ISubmissionRepository _repository): GenService<SubmissionEntity, SubmissionDto, SubmissionSaveDto, Guid>(_repository), ISubmissionService
{

}
