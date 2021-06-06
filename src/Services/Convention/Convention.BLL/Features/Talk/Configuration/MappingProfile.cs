using AutoMapper;
using Convention.Contracts.Models.Talk;

namespace Convention.BLL.Features.Talk.Commands
{
    public class TalkMappingProfile : Profile
    {
        public TalkMappingProfile()
        {
            CreateMap<Domain.Talk, TalkResponse>();
        }
    }
}