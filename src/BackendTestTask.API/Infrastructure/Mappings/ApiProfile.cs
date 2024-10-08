using AutoMapper;
using BackendTestTask.BusinessLogic.DTOs;
using BackendTestTask.BusinessLogic.Models;
using BackendTestTask.DataAccess.Entities;

namespace BackendTestTask.API.Infrastructure.Mappings;

public class ApiProfile : Profile
{
    public ApiProfile()
    {
        CreateMap<Node, NodeDto>();
        CreateMap<Tree, TreeDto>();

        CreateMap<SecurityExceptionLogCreateModel, SecurityExceptionLog>();
    }
}
