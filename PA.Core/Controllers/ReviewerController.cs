using Microsoft.AspNetCore.Mvc;
using PA.Interfaces;
using PA.Interfaces.Models.Reviewer;

namespace PublicationApp.Controllers;

/// <summary>
///     Ревьюеры
/// </summary>
[Route("/[controller]")]
[Produces("application/json")]
public class ReviewerController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IReviewerService _reviewersService;

    public ReviewerController(IReviewerService reviewersService)
    {
        _reviewersService = reviewersService;
    }

    /// <summary>
    ///     Добавить ревьюера
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route($"{nameof(Add)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    public async Task<BaseResponse<long>> Add([FromBody] AddReviewerRequest request)
    {
        var result = await _reviewersService.AddReviewerAsync(request);
        return new BaseResponse<long>(result);
    }

    /// <summary>
    ///     Получить ревьюеров
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route($"{nameof(Get)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<GetReviewerResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    public async Task<BaseResponse<GetReviewerResponse>> Get([FromQuery] GetReviewerRequest request)
    {
        var result = await _reviewersService.GetReviewers(request);
        return new BaseResponse<GetReviewerResponse>(result);
    }

    /// <summary>
    ///     Получить идентификаторы публикаций ревьюера
    /// </summary>
    /// <param name="reviewerId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route($"{nameof(GetPublications)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<IReadOnlyCollection<long>>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    public async Task<BaseResponse<IReadOnlyCollection<long>>> GetPublications([FromQuery] long reviewerId)
    {
        var result = await _reviewersService.GetReviewerPublication(reviewerId);
        return new BaseResponse<IReadOnlyCollection<long>>(result);
    }
}