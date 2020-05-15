using AutoMapper;
using KnowledgeTestingService.API.Models.TestManagement;
using KnowledgeTestingService.API.Models.TestQuerying;
using KnowledgeTestingService.API.Models.TestResult;
using KnowledgeTestingService.BLL.TestResults;
using KnowledgeTestingService.BLL.Tests;

namespace KnowledgeTestingService.API.MappingConfigurations
{
    public class TestDtoModelMappingProfile : Profile
    {
        public TestDtoModelMappingProfile()
        {
            CreateMap<FullTestDto, FullTestModel>();
            CreateMap<TestInfoDto, TestInfoModel>();
            
            CreateMap<EditTestDto, EditTestModel>();
            CreateMap<EditTestModel, EditTestDto>();

            CreateMap<UserAnswersModel, TestResultCreateDto>();

            CreateMap<TestResultDto, TestResultModel>();
        }
    }
}