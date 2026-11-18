using Shop.Domain.Dto.Filters;
using Shop.Domain.Dto.Query;

namespace Shop.Client.Models;

public class SalesReportModel
{
    public IEnumerable<SoldItemDto> Items { get; set; } = Enumerable.Empty<SoldItemDto>();
    public SoldItemFilterDto Filter { get; set; } = new(null, null);
}
