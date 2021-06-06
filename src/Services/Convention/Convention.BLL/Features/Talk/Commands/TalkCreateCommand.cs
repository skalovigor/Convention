using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Infrastructure.Behaviours;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Talk.Commands
{
    public record TalkCreateCommand : IRequest,
        IValidateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public int AmountOfSeats { get; set; }
        public Guid SpeakerId { get; set; }
        public Guid ConventionId { get; set; }
    }

    internal class TalkCreateCommandHandler : IRequestHandler<TalkCreateCommand>
    {
        private readonly IUnitOfWorkAccessor _unitOfWorkAccessor;

        public TalkCreateCommandHandler(IUnitOfWorkAccessor unitOfWorkAccessor)
        {
            _unitOfWorkAccessor = unitOfWorkAccessor;
        }

        public Task<Unit> Handle(TalkCreateCommand request, CancellationToken cancellationToken)
        {
            using var unitOfWOrk = _unitOfWorkAccessor.UnitOfWork;

            var entity = new Domain.Talk
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                SpeakerId = request.SpeakerId,
                Date = request.Date,
                ImageUrl = request.ImageUrl,
                Description = request.Description,
                AmountOfSeats = request.AmountOfSeats,
                ConventionId = request.ConventionId
            };
            
            unitOfWOrk.TalkRepo.Add(entity);
            return Task.FromResult(Unit.Value);
        }
    } 
}