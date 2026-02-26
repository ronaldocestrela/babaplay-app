using BabaPlayApp.Pages.Tenancy;
using BabaPlayShared.Library.Constants;
using BabaPlayShared.Library.Models.Responses.Associations;
using App.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace BabaPlayApp.Pages.Associations
{
    public partial class AssociationList
    {
        [CascadingParameter]
        protected Task<AuthenticationState> AuthState { get; set; } = default!;

        [Inject]
        protected IAuthorizationService AuthService { get; set; } = default!;

        private bool _isLoading = true;

        private bool _canCreateAssociations;
        private bool _canUpdateAssociations;
        private bool _canDeleteAssociations;

        private List<AssociationResponse> _associationList = [];

        protected override async Task OnInitializedAsync()
        {
            var user = (await AuthState).User;

            _canCreateAssociations = await AuthService.HasPermissionAsync(user, AssociationFeature.Associations, AssociationAction.Create);
            _canUpdateAssociations = await AuthService.HasPermissionAsync(user, AssociationFeature.Associations, AssociationAction.Update);
            _canDeleteAssociations = await AuthService.HasPermissionAsync(user, AssociationFeature.Associations, AssociationAction.Delete);

            // Load Associations
            await LoadAssociationsAsync();
            _isLoading = false;
        }

        private async Task LoadAssociationsAsync()
        {
            var result = await _associationService.GetAllAsync();
            if (result.IsSuccessful)
            {
                _associationList = result.Data!;
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }
        }

        private async Task OnBoardNewAssociationAsync()
        {
            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true,
                BackdropClick = false
            };

            var dialog = await _dialogService.ShowAsync<CreateAssociation>(title: null, options);

            var result = await dialog.Result;

            if (!result!.Canceled)
            {
                await LoadAssociationsAsync();
            }
        }

        private void Cancel()
        {
            _navigation.NavigateTo("/");
        }
    }
}
