using AutoMapper;
using KnowledgeTestingService.DAL.Entities;

namespace KnowledgeTestingService.BLL.Tests
{
    public class TestEntityDtoMappingProfile : Profile
    {
        public TestEntityDtoMappingProfile()
        {
            CreateMap<Test, FullTestDto>()
                .ForPath(dest => dest.Time, src => src.MapFrom(t=> t.Time.Ticks));
            CreateMap<Test, TestInfoDto>()
                .ForPath(dest => dest.Time, src => src.MapFrom(t=> t.Time.Ticks));
        }
    }
}