using App.Infrastructure.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BabaPlayApp.Pages.Auth
{
    public partial class Login
    {
        private LoginRequest _loginRequest = new();

        private InputType _inputType = InputType.Password;
        private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
        private bool _isPasswordVisisble;
        private MudForm? _form = default;
        private string? tenant;
        [Inject] private NavigationManager _navigationManager { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            var state = await _applicationStateProvider.GetAuthenticationStateAsync();
            if (state.User.Identity?.IsAuthenticated is true)
            {
                _navigation.NavigateTo("/");
            }
        }

        private async Task SubmitAsync()
        {
            await _form?.Validate()!;
            if (_form?.IsValid is not true) return;

            tenant = _navigationManager.Uri.Split("://")[1].Split('.')[0];
            if (string.IsNullOrEmpty(tenant))
            {
                tenant = "root";
            }

            _loginRequest.Tenant = tenant;
            // Validation
            var result = await _tokenService
                .LoginAsync(tenant: tenant, request: _loginRequest);

            if (result.IsSuccessful)
            {
                _navigation.NavigateTo("/");
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }
        }

        void TogglePasswordVisibility()
        {
            if (_isPasswordVisisble)
            {
                _isPasswordVisisble = false;
                _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
                _inputType = InputType.Password;
            }
            else
            {
                _isPasswordVisisble = true; 
                _passwordInputIcon = Icons.Material.Filled.Visibility;
                _inputType = InputType.Text;
            }
        }      
        
        private void FillRootAdminCredentialsDuringDevelopment()
        {
            _loginRequest.Username = "admin.root@babaplay.com.br";
            _loginRequest.Password = "P@ssw0rd@123";
        }
    }
}
