using AutoMapper;
using KnowledgeTestingService.API.Models.TestManagement;
using KnowledgeTestingService.API.Models.TestQuerying;
using KnowledgeTestingService.BLL.Questions;

namespace KnowledgeTestingService.API.MappingConfigurations
{
    public class QuestionDtoModelMappingProfile : Profile
    {
        public QuestionDtoModelMappingProfile()
        {
            CreateMap<QuestionDto, QuestionModel>();

            CreateMap<EditQuestionDto, EditQuestionModel>();
            CreateMap<EditQuestionModel, EditQuestionDto>();
        }
    }
}