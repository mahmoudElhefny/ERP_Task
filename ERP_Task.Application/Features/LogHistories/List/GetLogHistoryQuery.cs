using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Application.Enums;
using ERP_Task.Application.Features.LogHistories.Dtos;
using ERP_Task.Application.Responses;
using ERP_Task.Application.Responses.Pagination;
using MediatR;

namespace ERP_Task.Application.Features.LogHistories.Get
{
    public class GetLogHistoryQuery :IRequest<OutputResponse<PagedResult<LogHistoryDto>>>
    {
        public string? Action { get; set; }
        public Guid? EntityId { get; set; }
        public DateTime? TimestampFrom { get; set; }
        public DateTime? TimestampTo { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

}

