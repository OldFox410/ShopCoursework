using Shop.Domain.Entities.Abstract;

namespace Shop.Domain.Entities;

public class Delivery : Entity
{
    public int SupplierId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal PurchasePrice { get; set; }
    public DateTime DeliveryDate { get; set; }
}
