using AutoMapper;
using KnowledgeTestingService.DAL.Entities;

namespace KnowledgeTestingService.BLL.Tests
{
    public class TestEntityDtoMappingProfile : Profile
    {
        public TestEntityDtoMappingProfile()
        {
            CreateMap<Test, FullTestDto>()
                .ForPath(dest => dest.Time, src => src.MapFrom(t=> t.Time.TotalMilliseconds));
            CreateMap<Test, TestInfoDto>()
                .ForPath(dest => dest.Time, src => src.MapFrom(t=> t.Time.TotalMilliseconds))
                .ForPath(dest => dest.QuestionsNumber, src => src.MapFrom(t => t.Questions.Count));
        }
    }
}