using AutoMapper;
using KnowledgeTestingService.API.Models.Authentication;
using KnowledgeTestingService.Authentication.DataTransferObjects;

namespace KnowledgeTestingService.API.MappingConfigurations
{
    public class AuthenticationDtoModelMappingProfile : Profile
    {
        public AuthenticationDtoModelMappingProfile()
        {
            CreateMap<UserRegisterModel, UserRegisterDto>();
            CreateMap<UserLoginModel, UserLogInDto>();
            CreateMap<TokenDto, TokenModel>();
        }
    }
}