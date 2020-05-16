using AutoMapper;
using KnowledgeTestingService.DAL.Entities;
using System;

namespace KnowledgeTestingService.BLL.TestResults
{
    public class TestResultEntityDtoMappingProfile : Profile
    {
        public TestResultEntityDtoMappingProfile()
        {
            CreateMap<TestResult, TestResultDto>()
                .ForMember(dst => dst.AttemptDate, src => src.MapFrom(tr => tr.AttemptDate.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds));
        }
    }
}