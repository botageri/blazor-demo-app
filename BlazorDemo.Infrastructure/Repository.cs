using BlazorDemo.Application.Data;
using BlazorDemo.Domain.Primitives;
using System.Collections.Generic;

namespace BlazorDemo.Infrastructure;

public abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : Entity, new()
{
    protected readonly JsonApplicationDbContext DbContext;

    protected Repository(JsonApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public void Add(TEntity entity)
    {
        DbContext.Add(entity);
    }

    public void Delete(TEntity entity)
    {
        DbContext.Delete(entity);
    }

    public TEntity Get(int id)
    {

        return DbContext.GetAll<TEntity>().FirstOrDefault(x => x.Id == id)!;
    }

    public IQueryable<TEntity> GetAll()
    {
        return DbContext.GetAll<TEntity>().ToList().AsQueryable();
    }

    public void Update(TEntity entity)
    {
        DbContext.Update(entity);
    }
}