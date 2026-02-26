using BabaPlayShared.Library.Constants;
using Microsoft.AspNetCore.Authorization;

namespace App.Infrastructure.Services.Auth;

public class ShouldHavePermissionAttribute : AuthorizeAttribute
{
    public ShouldHavePermissionAttribute(string action, string feature)
    {
        Policy = AssociationPermission.NameFor(action, feature);
    }
}
