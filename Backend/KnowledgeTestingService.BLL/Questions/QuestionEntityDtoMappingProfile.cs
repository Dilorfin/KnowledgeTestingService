using AutoMapper;
using KnowledgeTestingService.DAL.Entities;

namespace KnowledgeTestingService.BLL.Questions
{
    public class QuestionEntityDtoMappingProfile : Profile
    {
        public QuestionEntityDtoMappingProfile()
        {
            CreateMap<Question, QuestionDto>();
        }
    }
}