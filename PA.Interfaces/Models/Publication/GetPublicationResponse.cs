using PA.Interfaces.Pagination;

namespace PA.Interfaces.Models.Publication;

public class GetPublicationResponse : IPaginationResponse<PublicationModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<PublicationModel> Items { get; set; }
}