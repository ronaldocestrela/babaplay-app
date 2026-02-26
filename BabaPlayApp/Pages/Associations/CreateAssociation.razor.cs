using BabaPlayShared.Library.Models.Requests.Associations;
using App.Infrastructure.Validators;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BabaPlayApp.Pages.Associations
{
    public partial class CreateAssociation
    {
        [CascadingParameter] private IMudDialogInstance? _dialogInstance { get; set; }
        private CreateAssociationRequest CreateAssociationRequest { get; set; } = new();
        private MudForm? _form;
        private MudDatePicker _datePicker = default!;
        private CreateAssociationRequestValidator _validator = new();

        private DateTime? EstablishedDatePicker
        {
            get => CreateAssociationRequest.EstablishedDate == default
                ? null
                : CreateAssociationRequest.EstablishedDate;
            set
            {
                if (value.HasValue)
                {
                    CreateAssociationRequest.EstablishedDate = value.Value;
                }
            }
        }

        private async Task SubmitAsync()
        {
            await _form!.Validate();
            if (_form.IsValid)
            {
                await SaveAssociationAsync();
            }
        }

        private async Task SaveAssociationAsync()
        {
            var result = await _associationService.CreateAsync(CreateAssociationRequest);
            if (result.IsSuccessful)
            {
                _snackbar.Add(result.Messages[0], Severity.Success);
                _dialogInstance!.Close(DialogResult.Ok(true));
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }
        }
        private void CancelDialog()
        {
            _dialogInstance!.Close();
        }
    }
}
