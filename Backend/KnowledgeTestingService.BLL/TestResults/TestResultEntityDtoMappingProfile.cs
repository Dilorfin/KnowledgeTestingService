using AutoMapper;
using KnowledgeTestingService.DAL.Entities;

namespace KnowledgeTestingService.BLL.TestResults
{
    public class TestResultEntityDtoMappingProfile : Profile
    {
        public TestResultEntityDtoMappingProfile()
        {
            CreateMap<TestResult, TestResultDto>();
        }
    }
}