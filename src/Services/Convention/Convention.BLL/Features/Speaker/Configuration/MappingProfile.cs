using AutoMapper;
using Convention.BLL.Features.Speaker.Commands;
using Convention.Contracts.Models.Speaker;
using Convention.Contracts.Models.Talk;

namespace Convention.BLL.Features.Speaker.Configuration
{
    public class SpeakerMappingProfile : Profile
    {
        public SpeakerMappingProfile()
        {
            CreateMap<SpeakerCreateRequest, SpeakerCreateCommand>();
            CreateMap<Domain.Models.Speaker, SpeakerResponse>();
        }
    }
}