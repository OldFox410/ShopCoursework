using Microsoft.Extensions.Configuration;
using Shop.Domain.Dto.Filters;
using Shop.Domain.Dto.Query;
using Shop.Domain.Entities;

namespace Shop.Application.Queries;

public class EmployeeQuery : DataBaseQuery<Employee, EmployeeDto, EmployeeFilter>
{
    protected override string _queryString => @"
            SELECT Id, LastName, FirstName, MiddleName, Position, Phone, HireDate, HasChildren
            FROM Employees
            WHERE (@HasChildren IS NULL OR HasChildren = @HasChildren)
            ORDER BY LastName, FirstName;";

    public EmployeeQuery(IConfiguration config) : base(config) { }
}