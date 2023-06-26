using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PA.Data.Enums;
using PA.Interfaces;
using PA.Interfaces.Models.Publication;

namespace PublicationApp.Controllers;

/// <summary>
/// Публикации
/// </summary>
[Route("/[controller]")]
[Produces("application/json")]
public class PublicationController : Microsoft.AspNetCore.Mvc.Controller
{
	private readonly IPublicationService _publication;

	public PublicationController(IPublicationService publication)
	{
		_publication = publication;
	}

	/// <summary>
	///     Добавить публикацию
	/// </summary>
	/// <param name="model"></param>
	/// <returns></returns>
	[HttpPost]
	[Authorize]
	[Route($"{nameof(Add)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<long>> Add([FromBody] AddPublicationModel model)
	{
		var result = await _publication.AddPublicationAsync(model);
		return new BaseResponse<long>(result);
	}

	/// <summary>
	///     Получить все публикации
	/// </summary>
	/// <param name="model"></param>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(Get)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<GetPublicationResponse>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<GetPublicationResponse>> Get([FromQuery] GetPublicationRequest model)
	{
		var result = await _publication.GetPublicationAsync(model);
		return new BaseResponse<GetPublicationResponse>(result);
	}

	/// <summary>
	///     Установить статус публикации
	/// </summary>
	/// <param name="id"></param>
	/// <param name="status"></param>
	/// <returns></returns>
	[HttpPatch]
	[Authorize]
	[Route($"{nameof(SetStatus)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse> SetStatus([FromQuery] long id, [FromQuery] EnumPublicationStatus status)
	{
		await _publication.SetPublicationStatusAsync(id, status);
		return new BaseResponse();
	}

	/// <summary>
	///     Обновить публикацию
	/// </summary>
	/// <param name="model"></param>
	/// <returns></returns>
	[HttpPatch]
	[Authorize]
	[Route($"{nameof(Update)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse> Update([FromBody] UpdatePublicationModel model)
	{
		await _publication.UpdatePublicationAsync(model);
		return new BaseResponse();
	}
}