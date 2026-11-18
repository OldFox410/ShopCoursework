using Shop.Domain.Entities.Abstract;

namespace Shop.Domain.Entities;

public class Sale : Entity
{
    public int EmployeeId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalAmount { get; set; }
}
