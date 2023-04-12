using PA.Interfaces.Pagination;

namespace PA.Interfaces.Models.Department;

public class GetDepartmentRequest: IPaginationRequest
{
    public long? DepartmanetId { get; set; } = null;

    public Page Page { get; set; } = new Page();
}