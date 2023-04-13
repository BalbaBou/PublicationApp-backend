using PA.Interfaces.Pagination;

namespace PA.Interfaces.Models.Reviewer;

public class GetReviewerResponse: IPaginationResponse<ReviewerModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<ReviewerModel> Items { get; set; }
}