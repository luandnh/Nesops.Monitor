using System;
using FluentValidation;
using NesopsService.Domain.Models;

namespace NesopsService.Domain.Validation
{
    public partial class ApplicationsCreateModelValidator
        : AbstractValidator<ApplicationsCreateModel>
    {
        public ApplicationsCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(200);
            RuleFor(p => p.DisplayName).MaximumLength(200);
            RuleFor(p => p.UrlAddress).MaximumLength(200);
            #endregion
        }

    }
}
