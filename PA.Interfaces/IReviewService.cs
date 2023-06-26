using PA.Interfaces.Models;
using PA.Interfaces.Models.Review;

namespace PA.Interfaces;

public interface IReviewService
{
    Task CheckAccessToReview(long publicationId, long reviewerId);

    Task<long> AddReviewAsync(long publicationId, string comment);

    Task<IReadOnlyCollection<ReviewModel>> GetPublicationReview(long publicationId);

    Task RemoveReviewAsync(long reviewId);
    
}