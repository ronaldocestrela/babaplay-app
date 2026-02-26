using System.Security.Claims;
using BabaPlayShared.Library.Constants;
using Microsoft.AspNetCore.Authorization;

namespace App.Infrastructure.Extensions;

public static class AuthorizationServiceExtensions
{
    public static async Task<bool> HasPermissionAsync(
            this IAuthorizationService service,
            ClaimsPrincipal user,
            string feature,
            string action)
    {
        return (await service.AuthorizeAsync(user, null, AssociationPermission.NameFor(action, feature))).Succeeded;
    }
}
