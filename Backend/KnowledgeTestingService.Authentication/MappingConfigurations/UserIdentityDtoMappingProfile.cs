using AutoMapper;
using KnowledgeTestingService.Authentication.DataTransferObjects;

namespace KnowledgeTestingService.Authentication.MappingConfigurations
{
    public class UserIdentityDtoMappingProfile : Profile
    {
        public UserIdentityDtoMappingProfile()
        {
            CreateMap<User, UserDto>().ForPath(dest => dest.LockoutEnd, src =>
                    src.MapFrom(u => u.LockoutEnd.HasValue ? u.LockoutEnd.Value.ToUnixTimeMilliseconds() : (long?)null)
                );
        }
    }
}