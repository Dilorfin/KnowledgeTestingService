using AutoMapper;
using KnowledgeTestingService.API.Models.Test.Answer;
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