using System;
using System.Security.Policy;
using AutoMapper;
using Convention.Contracts.Models.Talk;

namespace Convention.BLL.Features.Talk.Commands
{
    public class TalkMappingProfile : Profile
    {
        public TalkMappingProfile()
        {
            CreateMap<Domain.Models.Talk, TalkResponse>();
            CreateMap<TalkCreateRequest, TalkCreateCommand>()
                .ForMember(m=> m.StartTime, 
                    c=> c.MapFrom(f=>TimeSpan.Parse(f.StartTime)))
                .ForMember(m=> m.EndTime, 
                    c=> c.MapFrom(f=>TimeSpan.Parse(f.EndTime)));
        }
    }
}