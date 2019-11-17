using System;
using System.Collections.Generic;
using System.Text;

namespace NesopsService.Identifier
{
    public interface IHaveIdentifier
    {
        Guid Id { get; set; }
    }
}
