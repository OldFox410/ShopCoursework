using Shop.Domain.Entities.Abstract;

namespace Shop.Domain.Entities;

public class Category : Entity
{
    public string Name { get; set; } = string.Empty;
}
