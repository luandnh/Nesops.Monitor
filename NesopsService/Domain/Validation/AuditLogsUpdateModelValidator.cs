using System;
using System.Collections.Generic;
using FluentValidation;
using NesopsService.Domain.Models;

namespace NesopsService.Domain.Validation
{
    public partial class AuditLogsUpdateModelValidator
        : AbstractValidator<AuditLogsUpdateModel>
    {
        public AuditLogsUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Message).NotEmpty();
            RuleFor(p => p.Message).MaximumLength(500);
            RuleFor(p => p.Level).MaximumLength(50);
            #endregion
            RuleFor(p => p.Level).NotEmpty().Must(p => {
                List<string> LogLevels = new List<string> { "Information", "Warning", "Error" };
                return LogLevels.Contains(p);
            }).WithMessage("Log level must be :Information, Warning or Error"); ;
        }

    }
}
