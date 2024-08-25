using System.Linq.Expressions;
using System.Runtime.InteropServices;
using domain;

namespace service;

public interface IGenRepository<T, TId> where T : BaseEntity<TId> where TId : IEquatable<TId>
{
  IQueryable<T> GetAll();
  Task<T?> GetById(TId id);
  Task<T> Save(T entity, [Optional] TId? id);
  Task Delete(TId id);
  IQueryable<T> SetFilter(Expression<Func<T, bool>> filter);
  Task<T?> Get(Expression<Func<T, bool>> filter);
}
