using Shop.Domain.Entities.Abstract;

namespace Shop.Domain.Entities;

public class Product : Entity
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Article { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int StockQuantity { get; set; }
}
