using PA.Interfaces.Pagination;

namespace PA.Interfaces.Models.Department;

public class GetDepartmentsResponse : IPaginationResponse<DepartmentShortModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<DepartmentShortModel> Items { get; set; }
}