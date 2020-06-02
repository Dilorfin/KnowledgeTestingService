using AutoMapper;
using KnowledgeTestingService.DAL.Entities;
using System;

namespace KnowledgeTestingService.BLL.Tests
{
    public class TestEntityDtoMappingProfile : Profile
    {
        public TestEntityDtoMappingProfile()
        {
            CreateMap<Test, EditTestDto>()
                .ForPath(dest => dest.Time, src => src.MapFrom(t=> t.Time.TotalMilliseconds));
            CreateMap<AddTestDto, Test>()
                .ForPath(dest => dest.Time, src => src.MapFrom(t=> TimeSpan.FromMilliseconds(t.Time)));

            CreateMap<Test, FullTestDto>()
                .ForPath(dest => dest.Time, src => src.MapFrom(t=> t.Time.TotalMilliseconds));
            CreateMap<Test, TestInfoDto>()
                .ForPath(dest => dest.Time, src => src.MapFrom(t=> t.Time.TotalMilliseconds))
                .ForPath(dest => dest.QuestionsNumber, src => src.MapFrom(t => t.Questions.Count));
        }
    }
}