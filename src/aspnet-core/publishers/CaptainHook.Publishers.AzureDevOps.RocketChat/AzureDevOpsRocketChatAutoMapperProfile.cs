using AutoMapper;
using CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps;
using CaptainHook.Receivers.AzureDevOps.Payload;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat
{
    public class AzureDevOpsRocketChatAutoMapperProfile : Profile
    {
        public AzureDevOpsRocketChatAutoMapperProfile()
        {
            CreateMap<GitUser, AzureDevOpsIdentity>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.DisplayName, map => map.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.UniqueName, map => map.MapFrom(src => src.UniqueName))
                .ForMember(dest => dest.ImageUrl, map => map.MapFrom(src => src.ImageUrl));
        }
    }
}
