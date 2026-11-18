using Microsoft.Extensions.Configuration;
using Shop.Domain.Dto.Filters;
using Shop.Domain.Dto.Query;
using Shop.Domain.Entities;

namespace Shop.Application.Queries;

public class SalesQuery : DataBaseQuery<Sale, SoldItemDto, SoldItemFilterDto>
{
    protected override string _queryString => @"
            SELECT 
                p.Name AS ProductName,
                p.Article,
                si.Quantity,
                si.PriceAtSale,
                (si.Quantity * si.PriceAtSale) AS TotalCost,
                s.SaleDate
            FROM SaleItems si
            JOIN Products p ON si.ProductId = p.Id
            JOIN Sales s ON si.SaleId = s.Id
            WHERE (@MinPrice IS NULL OR si.PriceAtSale >= @MinPrice)
              AND (@StartDate IS NULL OR s.SaleDate >= @StartDate)
            ORDER BY si.PriceAtSale DESC, s.SaleDate DESC;";

    public SalesQuery(IConfiguration config) : base(config) { }
}
