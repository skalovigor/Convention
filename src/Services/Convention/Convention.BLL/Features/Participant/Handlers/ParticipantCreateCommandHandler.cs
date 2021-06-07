using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Participant.Commands;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Participant.Handlers
{
    internal class ParticipantCreateCommandHandler : IRequestHandler<ParticipantCreateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParticipantCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Unit> Handle(ParticipantCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Models.Participant
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Address = request.Address,
                ConventionId = request.ConventionId,
                Email = request.Email,
                Phone = request.Phone,
                UserId = request.UserId
            };
            
            _unitOfWork.ParticipantRepo.Add(entity);
            await _unitOfWork.SubmitChanges();
            return Unit.Value;
        }
    }
}