using System;
using FluentValidation;
using NesopsService.Domain.Models;

namespace NesopsService.Domain.Validation
{
    public partial class LogsUpdateModelValidator
        : AbstractValidator<LogsUpdateModel>
    {
        public LogsUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Message).NotEmpty();
            RuleFor(p => p.Message).MaximumLength(500);
            RuleFor(p => p.Level).NotEmpty();
            RuleFor(p => p.Level).MaximumLength(50);
            #endregion
        }

    }
}
