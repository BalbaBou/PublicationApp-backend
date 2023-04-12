using PA.Interfaces.Models.Author;

namespace PA.Interfaces;

public interface IAuthorService
{
    Task<AuthorShortModel> Add(AuthorAddModel model);

    Task<SearchAuthorResponse> SearchAuthor(AuthorGetModel model);

    Task<GetAuthorResponse> GetAuthorsAsync(GetAuthorRequest request);

    Task Update(AuthorUpdateModel model);

    Task Remove(long id);
}