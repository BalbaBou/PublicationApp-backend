using PA.Interfaces.Pagination;

namespace PA.Interfaces.Models.Author;

public class AuthorGetModel : IPaginationRequest
{
    public string Search { get; set; } = string.Empty;

    public Page Page { get; set; } = new Page();
}