namespace BlazorDemo.Domain.Primitives;

public interface IRepository<TEntity> 
    where TEntity : Entity
{
    void Add(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    TEntity Get(int id);
    IQueryable<TEntity> GetAll();
}
