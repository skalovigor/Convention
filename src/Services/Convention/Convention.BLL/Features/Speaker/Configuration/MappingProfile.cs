using AutoMapper;
using Convention.BLL.Features.Speaker.Commands;
using Convention.Contracts.Models.Speaker;

namespace Convention.BLL.Features.Speaker.Configuration
{
    public class SpeakerMappingProfile : Profile
    {
        public SpeakerMappingProfile()
        {
            CreateMap<SpeakerCreateRequest, SpeakerCreateCommand>();
        }
    }
}