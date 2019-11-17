using System;
using FluentValidation;
using NesopsService.Domain.Models;

namespace NesopsService.Domain.Validation
{
    public partial class ServerLogsUpdateModelValidator
        : AbstractValidator<ServerLogsUpdateModel>
    {
        public ServerLogsUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Message).NotEmpty();
            RuleFor(p => p.Message).MaximumLength(500);
            #endregion
        }

    }
}
