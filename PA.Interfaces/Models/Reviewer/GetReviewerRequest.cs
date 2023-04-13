using PA.Interfaces.Pagination;

namespace PA.Interfaces.Models.Reviewer;

public class GetReviewerRequest: IPaginationRequest
{
    public string Search { get; set; } = string.Empty;

    public long? PublicationId { get; set; }

    public long? ReviewerId { get; set; }

    public Page Page { get; set; } = new Page();
}