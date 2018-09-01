using AutoMapper;

namespace TaskList.Domain.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }

        static AutoMapperConfig()
        {
            RegisterMappings();
        }

        public static void RegisterMappings()
        {
            Mapper = new MapperConfiguration(map =>
            {
                map.AddProfile(new TaskToTaskOutputModelMappingProfile());
            })
            .CreateMapper();
        }
    }
}
