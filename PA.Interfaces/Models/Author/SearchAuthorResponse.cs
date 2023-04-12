using PA.Interfaces.Pagination;

namespace PA.Interfaces.Models.Author;

public class SearchAuthorResponse : IPaginationResponse<AuthorShortModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<AuthorShortModel> Items { get; set; }
}