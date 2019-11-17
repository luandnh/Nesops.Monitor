using System;
using FluentValidation;
using NesopsService.Domain.Models;

namespace NesopsService.Domain.Validation
{
    public partial class ServerLogsCreateModelValidator
        : AbstractValidator<ServerLogsCreateModel>
    {
        public ServerLogsCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Message).NotEmpty();
            RuleFor(p => p.Message).MaximumLength(500);
            #endregion
        }

    }
}
