namespace Shop.Domain.Entities.Abstract;

public abstract class Entity
{
    public int Id { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) 
            return false;

        if(obj is not Entity entity) 
            return false;

        if (GetType() != obj.GetType())
            return false;

        if(Id != entity.Id) 
            return false;

        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, GetType());
    }
}
