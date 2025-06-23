using AutoMapper;
using ERP_Task.Application.Features.Employees.Dtos;
using ERP_Task.Application.Mappings;

namespace ERP_Task.Application.Features.LogHistories.Dtos
{
    public class LogHistoryDto : IMapFrom<ERP_Task.Domain.Entities.LogHistory>
    {
        public Guid Id { get; set; }
        public string Action { get; set; } = default!;
        public string EntityName { get; set; } = default!;
        public Guid EntityId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Description { get; set; } = default!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ERP_Task.Domain.Entities.LogHistory, LogHistoryDto>().ReverseMap();
        }
    }
}
