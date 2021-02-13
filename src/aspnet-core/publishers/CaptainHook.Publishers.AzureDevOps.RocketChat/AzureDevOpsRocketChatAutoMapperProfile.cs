using AutoMapper;
using CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps;
using Microsoft.VisualStudio.Services.Identity;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat
{
    public class AzureDevOpsRocketChatAutoMapperProfile : Profile
    {
        public AzureDevOpsRocketChatAutoMapperProfile()
        {
            CreateMap<Identity, AzureDevOpsIdentityDto>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.DisplayName, map => map.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.IsActive, map => map.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.IsContainer, map => map.MapFrom(src => src.IsContainer))
                .ForMember(dest => dest.MemberIds, map => map.MapFrom(src => src.MemberIds))
                .ForMember(dest => dest.Properties, map => map.MapFrom(src => src.Properties));
        }
    }
}
