﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Task.Application.Responses
{
    public class OutputResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Model { get; set; }
        public List<ErrorModel> Errors { get; set; } = new();
    }
    public class ErrorModel
    {
        public string Property { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
    }
}
