using domain;
using service;

namespace application;

public class CourseService(ICourseRepository _repository): GenService<CourseEntity, CourseDto, CourseSaveDto, int>(_repository), ICourseService
{

}
