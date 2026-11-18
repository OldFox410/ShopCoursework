using Shop.Domain.Dto.Filters;
using Shop.Domain.Dto.Query;

namespace Shop.Client.Models;

public class EmployeesReportModel
{
    public IEnumerable<EmployeeDto> Items { get; set; } = Enumerable.Empty<EmployeeDto>();
    public EmployeeFilter Filter { get; set; } = new(null);
}