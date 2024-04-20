using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BlazorDemo.Domain.Primitives;

public abstract class Entity : IEqualityComparer<Entity>
{
    protected Entity()
    {

    }

    protected Entity(int id) {

        Id = id;
    }

    [Editable(false)]
    public int Id { get; init; }

    public bool Equals(Entity? x, Entity? y)
    {
        return x?.Id == y?.Id;
    }

    public int GetHashCode([DisallowNull] Entity obj)
    {
        return obj.Id.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Entity other = (Entity)obj;
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
