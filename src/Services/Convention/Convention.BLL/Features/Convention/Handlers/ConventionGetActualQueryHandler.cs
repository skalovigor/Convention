using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Convention.Query;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Convention.Handlers
{
    internal class ConventionGetActualQueryHandler : IRequestHandler<ConventionGetActualQuery,
        IReadOnlyCollection<Domain.Models.Convention>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConventionGetActualQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<Domain.Models.Convention>> Handle(ConventionGetActualQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ConventionRepo.WhereAsync(m => m.EndDate > DateTime.Now);
            return result.OrderBy(m => m.StartDate).ToList();
        }
    }
}