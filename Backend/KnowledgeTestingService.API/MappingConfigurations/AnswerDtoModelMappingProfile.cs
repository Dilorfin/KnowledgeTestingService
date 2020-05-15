using AutoMapper;
using KnowledgeTestingService.API.Models.TestManagement;
using KnowledgeTestingService.API.Models.TestQuerying;
using KnowledgeTestingService.BLL.Answers;

namespace KnowledgeTestingService.API.MappingConfigurations
{
    public class AnswerDtoModelMappingProfile : Profile
    {
        public AnswerDtoModelMappingProfile()
        {
            CreateMap<AnswerDto, AnswerModel>();
            CreateMap<EditAnswerDto, EditAnswerModel>();
            CreateMap<EditAnswerModel, EditAnswerDto>();
        }
    }
}