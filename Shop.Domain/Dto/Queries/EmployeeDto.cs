namespace Shop.Domain.Dto.Query;

public class EmployeeDto
{
    public int Id { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string Position { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public DateTime HireDate { get; set; }
    public bool HasChildren { get; set; }
}