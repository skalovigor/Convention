﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Talk.Queries
{
    public record TalkGetByIdQuery(Guid TalkId) : IRequest<Domain.Talk>
    {
        public static TalkGetByIdQuery Of(Guid talkId)
            => new(talkId);
    }

    internal class TalkGetByIdQueryHandler : IRequestHandler<TalkGetByIdQuery, Domain.Talk>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TalkGetByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Talk> Handle(TalkGetByIdQuery request, CancellationToken cancellationToken)
        {
            var talk = await _unitOfWork.TalkRepo.GetAsync(request.TalkId);
            return talk;
        }
    }
}