namespace Shop.Domain.Dto.Filters;

public record EmployeeFilter(bool? HasChildren);

public record TechSalesStatFilter();

public record SoldItemFilterDto(decimal? MinPrice, DateTime? StartDate);
