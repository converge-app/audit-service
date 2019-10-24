using Application.Models.DataTransferObjects;
using Application.Models.Entities;
using AutoMapper;

namespace Application.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Audit, AuditDto>();
            CreateMap<AuditDto, Audit>();
            CreateMap<AuditUpdateDto, Audit>();
            CreateMap<AuditCreationDto, Audit>();
        }
    }
}