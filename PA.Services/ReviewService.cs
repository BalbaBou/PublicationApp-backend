using Microsoft.EntityFrameworkCore;
using PA.Data;
using PA.Data.Models;
using PA.Interfaces;
using PA.Interfaces.Enums;
using PA.Interfaces.Exceptions;
using PA.Interfaces.Models.File;

namespace PA.Services;

public class ReviewService: IReviewService
{
    private readonly DataContext _db;

    public ReviewService(DataContext db)
    {
        _db = db;
    }

    public async Task CheckAccessToReview(long publicationId, long reviewerId)
    {
        if (!await _db.Publications.AnyAsync(x => x.Id == publicationId && x.ReviewerId == reviewerId))
            throw new PublicationAppException(EnumErrorCode.AccessDenied);
    }

    public async Task<long> AddReviewAsync(long publicationId, string comment)
    {
        var review = new Review
        {
            PublicationId = publicationId,
            Comment = comment
        };
        await _db.Reviews.AddAsync(review);
        await _db.SaveChangesAsync();
        return review.Id;
    }

    /*public async Task<IReadOnlyCollection<ReviewModel>> GetPublicationReview(long publicationId)
    {
        if (await _db.Publications.AllAsync(x => x.Id != publicationId))
            throw new PublicationAppException($"Publication id = {publicationId} is not exists!", EnumErrorCode.EntityIsNotFound);

        return await _db.Reviews
            .Where(x => x.PublicationId == publicationId)
            .Select(x => new ReviewModel
            {
                Id = x.Id,
                Comment = x.Comment,
                Files = x.Files.Select(f => new PublicationFileModel
                {
                    Name = f.Name,
                    ReviewId = f.ReviewId,
                    Type = f.Type,
                    Url = f.Url
                }).ToArray()
            })
            .ToArrayAsync();
    }*/

    public async Task RemoveReviewAsync(long reviewId)
    {
        if (await _db.Reviews.AllAsync(x => x.Id != reviewId))
            throw new PublicationAppException($"Review id = {reviewId} is not exists!", EnumErrorCode.EntityIsNotFound);

        _db.Reviews.Remove(new Review { Id = reviewId });
        await _db.SaveChangesAsync();
    }
}