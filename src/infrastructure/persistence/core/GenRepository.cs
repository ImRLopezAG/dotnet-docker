using System.Linq.Expressions;
using System.Runtime.InteropServices;
using domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using service;

namespace persistence;

public class GenRepository<T, TKey>(EmpContext _context) : IGenRepository<T, TKey> where TKey : IEquatable<TKey> where T : BaseEntity<TKey>
{
  protected readonly DbSet<T> _entities = _context.Set<T>();

  public async virtual Task<T?> Get(Expression<Func<T, bool>> filter) => await _entities.FirstOrDefaultAsync(filter);

  public virtual IQueryable<T> GetAll() => _entities.Where(e => !e.IsDeleted);

  public async virtual Task<T?> GetById(TKey id) => await _entities.FirstOrDefaultAsync(e => e.Id.Equals(id));

  public async virtual Task<T> Save(T entity, [Optional] TKey? id)
  {
    try
    {
      EntityEntry<T> result;
      if (id != null && !id.Equals(default(TKey)))
      {
        var existing = await GetById(id) ?? throw new Exception("Entity not found");
        _context.Entry(existing).CurrentValues.SetValues(entity);
        result = _context.Entry(existing);
        return result.Entity;
      }
      result = _entities.Add(entity);
      await _context.SaveChangesAsync();
      return result.Entity;
    }
    catch (Exception e)
    {
      throw new Exception(e.Message);
    }
  }

  public virtual IQueryable<T> SetFilter(Expression<Func<T, bool>> filter) => _entities.Where(filter);

  public async virtual Task Delete(TKey id)
  {
    var entity = await GetById(id) ?? throw new Exception("Entity not found");
    entity.IsDeleted = true;
    await Save(entity, id);
  }
}
