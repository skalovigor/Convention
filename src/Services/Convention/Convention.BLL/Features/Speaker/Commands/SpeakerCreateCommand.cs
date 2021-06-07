using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Speaker.Commands
{
    //TODO: validation
    public record SpeakerCreateCommand : IRequest
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string ProfileUrl { get; set; }
    }

    internal class SpeakerCreateCommandHandler : IRequestHandler<SpeakerCreateCommand>
    {
        private readonly IUnitOfWorkAccessor _unitOfWorkAccessor;

        public SpeakerCreateCommandHandler(IUnitOfWorkAccessor unitOfWorkAccessor)
        {
            _unitOfWorkAccessor = unitOfWorkAccessor;
        }

        public Task<Unit> Handle(SpeakerCreateCommand request, CancellationToken cancellationToken)
        {
            using var unitOfWOrk = _unitOfWorkAccessor.UnitOfWork;

            var entity = new Domain.Speaker
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Approved = false,
                Position = request.Position,
                ProfileUrl = request.ProfileUrl,
                UserId = request.UserId
            };
            unitOfWOrk.SpeakerRepo.Add(entity);

            return Task.FromResult(Unit.Value);
        }
    }
}