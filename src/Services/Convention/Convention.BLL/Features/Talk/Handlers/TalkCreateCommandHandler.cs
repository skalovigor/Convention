using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Talk.Commands;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Talk.Handlers
{
    internal class TalkCreateCommandHandler : IRequestHandler<TalkCreateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TalkCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Unit> Handle(TalkCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Models.Talk
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                SpeakerId = request.SpeakerId,
                Date = request.Date,
                Description = request.Description,
                AmountOfSeats = request.AmountOfSeats,
                ConventionId = request.ConventionId,
                StartTime = request.StartTime,
                EndTime = request.EndTime
            };
            
            _unitOfWork.TalkRepo.Add(entity);
            _unitOfWork.SubmitChanges();
            
            return Task.FromResult(Unit.Value);
        }
    } 
}