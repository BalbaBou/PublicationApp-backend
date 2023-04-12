using PA.Interfaces.Pagination;

namespace PA.Interfaces.Models.Author;

public class GetAuthorResponse : IPaginationResponse<AuthorModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<AuthorModel> Items { get; set; }
}