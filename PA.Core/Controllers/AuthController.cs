﻿using Microsoft.AspNetCore.Mvc;
using PA.Interfaces;
using PA.Interfaces.Models.Auth;

namespace PublicationApp.Controllers;

/// <summary>
/// Авторизация
/// </summary>
[Route("/[controller]")]
[Produces("application/json")]
public class AuthController : Microsoft.AspNetCore.Mvc.Controller
{
    [HttpPost]
    [Route($"{nameof(Login)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<LoginResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    public async Task<BaseResponse<LoginResponse>> Login([FromServices] IAuthService auth, [FromBody] LoginRequest request)
    {
        return await auth.Login(request);
    }

    [HttpPut]
    [Route($"{nameof(Register)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    public async Task<BaseResponse> Register([FromServices] IAuthService auth, [FromBody] RegisterRequest request)
    {
        return await auth.Register(request);
    }

    [HttpPatch]
    [Route($"{nameof(ActivateAccount)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<TokenResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    public async Task<BaseResponse> ActivateAccount([FromServices] IAuthService auth, [FromBody] ActivateAccountRequest request)
    {
        return await auth.ActivateAccount(request);
    }
}