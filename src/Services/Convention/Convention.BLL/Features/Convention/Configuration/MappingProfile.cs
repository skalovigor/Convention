using AutoMapper;
using Convention.BLL.Features.Convention.Commands;
using Convention.Contracts.Models;

namespace Convention.BLL.Features.Convention.Configuration
{
    public class ConventionMappingProfile : Profile
    {
        public ConventionMappingProfile()
        {
            CreateMap<ConventionCreateRequest, ConventionCreateCommand>();
        }
    }
}