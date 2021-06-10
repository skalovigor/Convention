using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Talk.Queries;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Talk.Handlers
{
    internal class TalkGetByIdQueryHandler : IRequestHandler<TalkGetByIdQuery, Domain.Models.Talk>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TalkGetByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Models.Talk> Handle(TalkGetByIdQuery request, CancellationToken cancellationToken)
        {
            var talk = await _unitOfWork.TalkRepo.GetAsync(request.TalkId);
            return talk;
        }
    }
}