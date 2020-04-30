using AutoMapper;
using KnowledgeTestingService.API.Models.Account;
using KnowledgeTestingService.Authentication.DataTransferObjects;

namespace KnowledgeTestingService.API.MappingConfigurations
{
    public class AccountDtoModelMappingProfile : Profile
    {
        public AccountDtoModelMappingProfile()
        {
            CreateMap<UserDto, UserModel>();
        }
    }
}