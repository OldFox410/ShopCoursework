using Microsoft.AspNetCore.Mvc;
using Shop.Application.Queries;
using Shop.Client.Models;
using Shop.Domain.Dto.Filters;

namespace Shop.Client.Controllers;
public class ReportsController : Controller
{
    private readonly SalesQuery _salesQuery;
    private readonly TechSalesQuery _techSalesQuery;
    private readonly EmployeeQuery _employeeQuery;

    public ReportsController(
        SalesQuery salesQuery, 
        TechSalesQuery techSalesQuery, 
        EmployeeQuery employeeQuery)
    {
        _salesQuery = salesQuery;
        _techSalesQuery = techSalesQuery;
        _employeeQuery = employeeQuery;
    }

    public async Task<IActionResult> Sales([FromQuery] SoldItemFilterDto filter)
    {
        var result = await _salesQuery.ExecuteAsync(filter);
        return View(
            new SalesReportModel
            {
                Filter = filter ?? new(null, null),
                Items = result
            });
    }

    public async Task<IActionResult> TechSales()
    {
        var result = await _techSalesQuery.ExecuteAsync(default!);
        return View(result);
    }

    public async Task<IActionResult> Employees([FromQuery] EmployeeFilter filter)
    {
        var result = await _employeeQuery.ExecuteAsync(filter);
        return View(
            new EmployeesReportModel 
            { 
                Filter = filter ?? new(null), 
                Items = result }
            );
    }

    public IActionResult Index()
    {
        return View();
    }
}
