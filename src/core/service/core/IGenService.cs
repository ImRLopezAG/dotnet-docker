using System.Linq.Expressions;
using System.Runtime.InteropServices;
using domain;

namespace service;

public interface IGenService<T, TDto, TSaveDto, TId> where T : BaseEntity<TId>
{
  Result<List<TDto>> GetAll();
  Task<Result<TDto?>> GetById(TId id);
  Task<Result<TDto>> Save(TSaveDto dto, [Optional] TId? id);
  Task Delete(TId id);
  Task<Result<TDto?>> Get(Expression<Func<TSaveDto, bool>> filter);
  IQueryable<T> SetFilter(Expression<Func<TSaveDto, bool>> filter);
}
