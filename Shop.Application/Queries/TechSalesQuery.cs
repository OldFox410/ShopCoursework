using Microsoft.Extensions.Configuration;
using Shop.Domain.Dto.Filters;
using Shop.Domain.Dto.Query;
using Shop.Domain.Entities;

namespace Shop.Application.Queries;

public class TechSalesQuery : DataBaseQuery<TechSalesStatDto, TechSalesStatFilter>
{
    protected override string _queryString => @"
            SELECT 
                p.Id AS ProductId,
                p.Name AS ProductName,
                p.Article,
                SUM(si.Quantity) AS TotalSoldCount,
                SUM(si.Quantity * si.PriceAtSale) AS TotalRevenue
            FROM SaleItems si
            JOIN Products p ON si.ProductId = p.Id
            JOIN Categories c ON p.CategoryId = c.Id
            WHERE c.Name LIKE N'%Бытовая техника%' OR c.Name LIKE N'Смартфоны и гаджеты'
            GROUP BY p.Id, p.Name, p.Article
            ORDER BY TotalSoldCount DESC;";

    public TechSalesQuery(IConfiguration config) : base(config) { }
}
