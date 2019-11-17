using System;
using System.Collections.Generic;
using System.Text;

namespace NesopsService.Service.Models
{
    public interface IRequestModelBase
    {
        int limit { get; set; }
        int skip { get; set; }
    }
    public class RequestModelBase : IRequestModelBase
    {
        public int limit { get; set; } = 10;
        public int skip { get; set; } = 0;
    }
}
