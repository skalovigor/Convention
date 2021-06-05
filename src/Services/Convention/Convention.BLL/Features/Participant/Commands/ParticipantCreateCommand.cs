using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Infrastructure.Behaviours;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Participant.Commands
{
    public record ParticipantCreateCommand : IRequest,
        IValidateRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid ConventionId { get; set; }
        public string UserId { get; set; }
    }
    
    internal class ParticipantCreateCommandHandler : IRequestHandler<ParticipantCreateCommand>
    {
        private readonly IUnitOfWorkAccessor _unitOfWorkAccessor;

        public ParticipantCreateCommandHandler(IUnitOfWorkAccessor unitOfWorkAccessor)
        {
            _unitOfWorkAccessor = unitOfWorkAccessor;
        }
        
        public Task<Unit> Handle(ParticipantCreateCommand request, CancellationToken cancellationToken)
        {
            using var unitOfWOrk = _unitOfWorkAccessor.UnitOfWork;

            var entity = new Domain.Participant
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Address = request.Address,
                ConventionId = request.ConventionId,
                Email = request.Email,
                Phone = request.Phone,
                UserId = request.UserId
            };
            
            unitOfWOrk.ParticipantRepo.Add(entity);
            
            return Task.FromResult(Unit.Value);
        }
    }
}