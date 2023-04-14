using PA.Interfaces.Models.Auth;

namespace PA.Interfaces;

public interface IAuthService
{
    Task<BaseResponse<LoginResponse>> Login(LoginRequest request);

    Task<BaseResponse> Register(RegisterRequest request);

    Task<BaseResponse<TokenResponse>> ActivateAccount(ActivateAccountRequest request);
}