using BabaPlayShared.Library.Constants;
using BabaPlayShared.Library.Models.Responses.Identity;
using App.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace BabaPlayApp.Pages.Identity
{
    public partial class Roles
    {
        [CascadingParameter]
        protected Task<AuthenticationState> AuthState { get; set; } = default!;

        [Inject]
        protected IAuthorizationService AuthService { get; set; } = default!;

        private List<RoleResponse> _roleList = [];

        private bool _isLoading = true;

        private bool _canCreateRoles;
        private bool _canUpdateRoles;
        private bool _canDeleteRoles;
        private bool _canViewRolePermissions;

        protected override  async Task OnInitializedAsync()
        {
            var user = (await AuthState).User;

            _canCreateRoles = await AuthService.HasPermissionAsync(user, AssociationFeature.Roles, AssociationAction.Create);
            _canUpdateRoles = await AuthService.HasPermissionAsync(user, AssociationFeature.Roles, AssociationAction.Update);
            _canDeleteRoles = await AuthService.HasPermissionAsync(user, AssociationFeature.Roles, AssociationAction.Delete);
            _canViewRolePermissions = await AuthService.HasPermissionAsync(user, AssociationFeature.RoleClaims, AssociationAction.Read);

            await LoadRolesAsync();
            _isLoading = false;
        }

        private async Task LoadRolesAsync()
        {
            var result = await _roleService.GetRolesAsync();
            if (result.IsSuccessful)
            {
                _roleList = result.Data!;
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }
        }

        private void ViewPermissions(string roleId)
        {
            _navigation.NavigateTo($"/role-permissions/{roleId}");
        }

        private void Cancel()
        {
            _navigation.NavigateTo("/");
        }
    }
}
