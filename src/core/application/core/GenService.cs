using System.Linq.Expressions;
using System.Runtime.InteropServices;
using domain;
using Mapster;
using service;

namespace application;

public class GenService<T, TDto, TSaveDto, TKey>(IGenRepository<T, TKey> _repository) : IGenService<T, TDto, TSaveDto, TKey> where T : BaseEntity<TKey> where TKey : IEquatable<TKey>
{

  public async Task<Result<TDto?>> Get(Expression<Func<TSaveDto, bool>> filter)
  {
    try
    {
      var entity = await _repository.Get(filter.Adapt<Expression<Func<T, bool>>>());
      if (entity == null) return Result<TDto?>.NotFound();
      return Result<TDto?>.Success(entity.Adapt<TDto>());
    }
    catch (Exception ex)
    {
      return Result<TDto?>.Failed(ex.Message, $"{ex.Source} - {typeof(T).Name} - Trace: {ex.StackTrace}");
    }
  }

  public Result<List<TDto>> GetAll()
  {
    try
    {
      var entities = _repository.GetAll().ToList();
      return Result<List<TDto>>.Success(entities.Adapt<List<TDto>>());
    }
    catch (Exception ex)
    {
      return Result<List<TDto>>.Failed(ex.Message, $"{ex.Source} - {typeof(T).Name} - Trace: {ex.StackTrace}");
    }
  }

  public async Task<Result<TDto?>> GetById(TKey id)
  {
    try
    {
      var entity = await _repository.GetById(id);
      if (entity == null)
      {
        return Result<TDto?>.NotFound();
      }
      return Result<TDto?>.Success(entity.Adapt<TDto>());
    }
    catch (Exception ex)
    {
      return Result<TDto?>.Failed(ex.Message, $"{ex.Source} - {typeof(T).Name} - Trace: {ex.StackTrace}");
    }
  }

  public async Task<Result<TDto>> Save(TSaveDto dto, [Optional] TKey? id)
  {
    try
    {
      var entity = await _repository.Save(dto.Adapt<T>(), id);
      return Result<TDto>.Success(entity.Adapt<TDto>());
    }
    catch (Exception ex)
    {
      return Result<TDto>.Failed(ex.Message, $"{ex.Source} - {typeof(T).Name} - Trace: {ex.StackTrace}");
    }
  }

  public IQueryable<T> SetFilter(Expression<Func<TSaveDto, bool>> filter)
  {
    try
    {
      return _repository.SetFilter(filter.Adapt<Expression<Func<T, bool>>>());
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
  public async Task Delete(TKey id)
  {
    try
    {
      await _repository.Delete(id);
    }
    catch (Exception ex)
    {
      Result<TDto>.Failed(ex.Message, $"{ex.Source} - {typeof(T).Name} - Trace: {ex.StackTrace}");
    }
  }
}