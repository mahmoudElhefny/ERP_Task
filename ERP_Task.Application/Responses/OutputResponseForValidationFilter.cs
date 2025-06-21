using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Task.Application.Responses
{
    public class OutputResponseForValidationFilter
    {
        [NotNull]
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public object Message { get; set; }
        public object Model { get; set; }
        public List<ErrorModel> Errors { get; set; } = new();
    }
}
