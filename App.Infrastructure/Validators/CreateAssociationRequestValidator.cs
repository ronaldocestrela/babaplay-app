using BabaPlayShared.Library.Models.Requests.Associations;
using FluentValidation;

namespace App.Infrastructure.Validators;

public class CreateAssociationRequestValidator : AbstractValidator<CreateAssociationRequest>
    {
        public CreateAssociationRequestValidator()
        {
            RuleFor(request => request.Name)
                //.NotEmpty()
                .Must(name => !string.IsNullOrEmpty(name))
                .WithMessage("Association Name is Required!");
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (request, propertyName) =>
        {
            var validationResult = await ValidateAsync(ValidationContext<CreateAssociationRequest>
                .CreateWithOptions((CreateAssociationRequest)request, vst => vst.IncludeProperties(propertyName)));

            if (validationResult.IsValid)
            {
                return [];
            }
            return validationResult.Errors.Select(e => e.ErrorMessage);
        };
    }
