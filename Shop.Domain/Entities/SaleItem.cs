using Shop.Domain.Entities.Abstract;

namespace Shop.Domain.Entities;

public class SaleItem : Entity
{
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal PriceAtSale { get; set; }
}