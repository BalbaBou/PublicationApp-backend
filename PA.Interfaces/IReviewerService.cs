using PA.Interfaces.Models.Reviewer;

namespace PA.Interfaces;

public interface IReviewerService
{
    Task<long> AddReviewerAsync(AddReviewerRequest request);

    Task<GetReviewerResponse> GetReviewers(GetReviewerRequest request);

    Task<IReadOnlyCollection<long>> GetReviewerPublication(long reviewerId);
}