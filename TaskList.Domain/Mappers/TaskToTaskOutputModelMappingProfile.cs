using AutoMapper;
using TaskList.Domain.Entities;
using TaskList.Domain.Models;

namespace TaskList.Domain.Mappers
{
    public class TaskToTaskOutputModelMappingProfile : Profile
    {
        public TaskToTaskOutputModelMappingProfile()
        {
            CreateMap<TaskModel, Task>()
                .ForMember(dest => dest.Events, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}