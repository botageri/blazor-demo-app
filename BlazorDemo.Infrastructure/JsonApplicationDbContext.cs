using BlazorDemo.Domain.Users;
using BlazorDemo.Application.Data;
using JsonNet.ContractResolvers;
using Newtonsoft.Json;
using BlazorDemo.Domain.Primitives;
using System.Runtime.CompilerServices;

namespace BlazorDemo.Infrastructure;

public class JsonApplicationDbContext : IUnitOfWork
{
    private static readonly object lockObject = new object();
    private readonly string _dbFilePath;

    private JsonApplicationDbContext(string dbFilePath)
    {
        _dbFilePath = dbFilePath;
        Users = new HashSet<User>();
    }

    public HashSet<User> Users {  get; private set; }

    public void Add<TEntity>(TEntity entity)
        where TEntity : Entity, new()
    {
        var set = this.Set<TEntity>();
        set.Add(entity);
    }

    public void Update<TEntity>(TEntity entity)
        where TEntity : Entity
    {
        var set = this.Set<TEntity>();
        set.Remove(entity);
        set.Add(entity);
    }

    public void Delete<TEntity>(TEntity entity)
        where TEntity : Entity
    {
        var set = this.Set<TEntity>();
        set.Remove(entity);
    }

    public HashSet<TEntity> GetAll<TEntity>() 
        where TEntity : Entity, new()
    {
        var property = typeof(JsonApplicationDbContext)
            .GetProperties()
            .FirstOrDefault(prop => prop.PropertyType.IsGenericType &&
                prop.PropertyType.GetGenericTypeDefinition() == typeof(HashSet<>) &&
                prop.PropertyType.GetGenericArguments().First() == typeof(TEntity));

        var set = property?.GetValue(this) as HashSet<TEntity>;

        if (set != null)
        {
            var newH = DTOUtils.CopyHashSet(set);
            return newH;
        }
        else
            throw new Exception("Nem található a keresett tábla!");
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        lock (lockObject)
        {
            var json = JsonConvert.SerializeObject(this);

            File.WriteAllText(_dbFilePath, json);
        }

        return Task.CompletedTask;
    }

    public static JsonApplicationDbContext Create(string path)
    {
        var appDbContext = new JsonApplicationDbContext(path);
        if(!File.Exists(path)) {
            appDbContext.SaveChangesAsync(CancellationToken.None);
        }

        string json = File.ReadAllText(path);

        JsonConvert.PopulateObject(
            json,
            appDbContext,
            new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            });

        return appDbContext;
    }

    private HashSet<TEntity> Set<TEntity>()
    where TEntity : Entity
    {
        var property = typeof(JsonApplicationDbContext)
            .GetProperties()
            .FirstOrDefault(prop => prop.PropertyType.IsGenericType &&
                prop.PropertyType.GetGenericTypeDefinition() == typeof(HashSet<>) &&
                prop.PropertyType.GetGenericArguments().First() == typeof(TEntity));

        var set = property?.GetValue(this) as HashSet<TEntity>;

        if (set != null)
        {
            return set;
        }
        else
            throw new Exception("Nem található a keresett tábla!");
    }
}
public static class DTOUtils
{
    public static TEntity CopyEntity<TEntity>(TEntity source) 
        where TEntity : new()
    {
        var destination = new TEntity();
        var properties = typeof(TEntity).GetProperties();
        foreach (var property in properties)
        {
            property.SetValue(destination, property.GetValue(source));
        }
        return destination;
    }

    public static HashSet<TEntity> CopyHashSet<TEntity>(HashSet<TEntity> source) 
        where TEntity : new()
    {
        var destination = new HashSet<TEntity>();
        foreach (var item in source)
        {
            destination.Add(CopyEntity(item));
        }

        return destination;
    }
}