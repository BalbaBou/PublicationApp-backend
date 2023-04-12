using PA.Interfaces.Pagination;

namespace PA.Interfaces.Models.Faculty;

public class GetFacultyRequest : IPaginationRequest
{
    public Page Page { get; set; } = new Page();
}