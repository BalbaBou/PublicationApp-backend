using Microsoft.AspNetCore.Mvc;
using PA.Interfaces;
using PA.Interfaces.Models.Review;

namespace PublicationApp.Controllers;

/// <summary>
///     Ревью
/// </summary>
[Route("/[controller]")]
[Produces("application/json")]
public class ReviewController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IReviewService _reviewsService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewsService = reviewService;
    }

    /// <summary>
    ///     Добавить ревью
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route($"{nameof(Add)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    public async Task<BaseResponse<long>> Add([FromBody] AddReviewRequest request)
    {
        var result = await _reviewsService.AddReviewAsync(request.PublicationId, request.Comment);
        return new BaseResponse<long>(result);
    }

    /// <summary>
    ///     Получить все ревью публикации
    /// </summary>
    /// <param name="publicationId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route($"{nameof(Get)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<IReadOnlyCollection<ReviewModel>>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    public async Task<BaseResponse<IReadOnlyCollection<ReviewModel>>> Get([FromQuery] long publicationId)
    {
        var result = await _reviewsService.GetPublicationReview(publicationId);
        return new BaseResponse<IReadOnlyCollection<ReviewModel>>(result);
    }

    /// <summary>
    ///     Удалить ревью
    /// </summary>
    /// <param name="reviewId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route($"{nameof(Delete)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    public async Task<BaseResponse> Delete([FromQuery] long reviewId)
    {
        await _reviewsService.RemoveReviewAsync(reviewId);
        return new BaseResponse();
    }
}