using domain;
using service;

namespace application;

public class GradeService(IGradeRepository _repository): GenService<GradeEntity, GradeDto, GradeSaveDto, Guid>(_repository), IGradeService
{

}
