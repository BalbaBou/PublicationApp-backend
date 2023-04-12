using PA.Interfaces.Pagination;

namespace PA.Interfaces.Models.Department;

public class GetDepartmentsRequest : IPaginationRequest
{
    public long? FacultyId { get; set; } = null;

    public Page Page { get; set; } = new Page();
}