using AutoMapper;
using BackendTestTask.BusinessLogic.DTOs;
using BackendTestTask.DataAccess.Entities;

namespace BackendTestTask.BusinessLogic.Mappings;

public class DtoProfile : Profile
{
    public DtoProfile()
    {
        CreateMap<Node, NodeDto>();
        CreateMap<Tree, TreeDto>();
        CreateMap<SecurityExceptionLogData, SecurityExceptionLogDataDto>();
        CreateMap<SecurityExceptionLog, SecurityExceptionLogDto>();
    }
}
