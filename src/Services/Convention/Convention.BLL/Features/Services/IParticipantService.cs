using System;
using System.Threading.Tasks;
using Convention.Contracts.Models.Participant;

namespace Convention.BLL.Features.Services
{
    public interface IParticipantService
    {
        Task ParticipateConvention(Guid conventionId, ParticipantCreateRequest request);
    }
}