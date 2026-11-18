using Shop.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dto.Query;
public class SoldItemDto
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string Article { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal PriceAtSale { get; set; }
    public decimal TotalCost { get; set; }
    public DateTime SaleDate { get; set; }
}
