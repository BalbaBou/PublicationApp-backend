using PA.Interfaces.Pagination;

namespace PA.Interfaces.Models.Author;

public class GetAuthorRequest : IPaginationRequest
{
    public long? AuthorId { get; set; } = null;

    public Page Page { get; set; } = new Page();
}