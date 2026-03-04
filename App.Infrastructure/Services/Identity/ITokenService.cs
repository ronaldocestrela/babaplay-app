using BabaPlayShared.Library.Models.Requests.Token;
using BabaPlayShared.Library.Wrappers;

namespace App.Infrastructure.Services.Identity;

public interface ITokenService
{
    Task<IResponseWrapper> LoginAsync(string tenant, TokenRequest request);
    Task<IResponseWrapper> LoginWebAsync(TokenRequest request);
    Task<IResponseWrapper> LogoutAsync();
    Task<string> RefreshTokenAsync();
    Task<string> TryForceRefreshTokenAsync();
}
