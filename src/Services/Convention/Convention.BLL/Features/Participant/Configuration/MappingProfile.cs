using AutoMapper;
using Convention.BLL.Features.Participant.Commands;
using Convention.Contracts.Models.Participant;

namespace Convention.BLL.Features.Participant.Configuration
{
    public class ParticipantMappingProfile : Profile
    {
        public ParticipantMappingProfile()
        {
            CreateMap<ParticipantCreateRequest, ParticipantCreateCommand>();
        }
    }
}