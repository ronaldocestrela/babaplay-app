using BabaPlayShared.Library.Constants;
using App.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BabaPlayApp.Layout
{
    public partial class NavMenu
    {
        [CascadingParameter]
        protected Task<AuthenticationState> AuthState { get; set; } = default!;

        [Inject]
        protected IAuthorizationService AuthService { get; set; } = default!;

        private bool _canViewTenants;
        private bool _canViewUsers;
        private bool _canViewRoles;
        private bool _canViewAssociations;

        protected override async Task OnParametersSetAsync()
        {
            var user = (await AuthState).User;

            _canViewTenants = await AuthService.HasPermissionAsync(user, AssociationFeature.Tenants, AssociationAction.Read);
            _canViewUsers = await AuthService.HasPermissionAsync(user, AssociationFeature.Users, AssociationAction.Read);
            _canViewRoles = await AuthService.HasPermissionAsync(user, AssociationFeature.Roles, AssociationAction.Read);
            _canViewAssociations = await AuthService.HasPermissionAsync(user, AssociationFeature.Associations, AssociationAction.Read);
        }
    }
}
