using System.ComponentModel;
using domain;
using Microsoft.EntityFrameworkCore;
using service;

namespace persistence;

public class CourseRepository(EmpContext _context) : GenRepository<CourseEntity, int>(_context), ICourseRepository
{
  public override IQueryable<CourseEntity> GetAll()
  {
    return _entities.Include(c => c.Professor).Include(c => c.Students);
  }

  public async override Task<CourseEntity?> GetById(int id) => await _entities.Include(c => c.Professor).Include(c => c.Students).FirstOrDefaultAsync(c => c.Id.Equals(id));

}
