using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP_Task.Application.Enums;
using ERP_Task.Application.Features.Employees.Dtos;
using ERP_Task.Application.Features.LogHistories.Dtos;
using ERP_Task.Application.Repositories;
using ERP_Task.Application.Responses;
using ERP_Task.Application.Responses.Pagination;
using MediatR;

namespace ERP_Task.Application.Features.LogHistories.Get
{
    public class GetLogHistoryQueryHandler : IRequestHandler<GetLogHistoryQuery,OutputResponse<PagedResult<LogHistoryDto>>>
    {
        private readonly ILogHistoryRepository _logHistoryRepository;
        private readonly IMapper _mapper;
        public GetLogHistoryQueryHandler(ILogHistoryRepository logHistoryRepository, IMapper mapper)
        {
            _logHistoryRepository = logHistoryRepository;
            _mapper = mapper;
        }
        public async Task<OutputResponse<PagedResult<LogHistoryDto>>> Handle(GetLogHistoryQuery request, CancellationToken cancellationToken)
        {
            // Build filter
            Expression<Func<ERP_Task.Domain.Entities.LogHistory, bool>> filter = e =>
                (string.IsNullOrEmpty(request.Action) || e.Action.Contains(request.Action)) &&
                (!request.TimestampFrom.HasValue || e.Timestamp >= request.TimestampFrom.Value) &&
                (!request.TimestampTo.HasValue || e.Timestamp <= request.TimestampTo.Value);

            // Get paged result from repo
            var paged = await _logHistoryRepository.GetPagedAsync(
                request.PageNumber,
                request.PageSize,
                filter,
                cancellationToken);

            // Map to DTOs
            var dtoItems = _mapper.Map<List<LogHistoryDto>>(paged.Items);
            return new OutputResponse<PagedResult<LogHistoryDto>>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Model = new PagedResult<LogHistoryDto>(dtoItems, paged.TotalCount, paged.PageNumber, paged.PageSize),
            };
        }
    }
}
