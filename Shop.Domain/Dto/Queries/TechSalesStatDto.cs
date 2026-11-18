namespace Shop.Domain.Dto.Query;

public class TechSalesStatDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string Article { get; set; } = string.Empty;
    public int TotalSoldCount { get; set; }
    public decimal TotalRevenue { get; set; }
}
