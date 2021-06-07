using System;
using Convention.BLL.Infrastructure.Behaviours;
using MediatR;

namespace Convention.BLL.Features.Convention.Commands
{
    public record ConventionCreateCommand : IRequest<Guid>,
        IValidateRequest
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Information { get; set; }
        public string BannerUrl { get; set; }
        public string Address { get; set; }
    }
}