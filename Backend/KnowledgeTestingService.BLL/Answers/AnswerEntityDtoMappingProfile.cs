using AutoMapper;
using KnowledgeTestingService.DAL.Entities;

namespace KnowledgeTestingService.BLL.Answers
{
    public class AnswerEntityDtoMappingProfile : Profile
    {
        public AnswerEntityDtoMappingProfile()
        {
            CreateMap<Answer, AnswerDto>();
            
            CreateMap<Answer, EditAnswerDto>();
            CreateMap<AddAnswerDto, Answer>();
        }
    }
}