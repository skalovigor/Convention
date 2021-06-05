using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Convention.Contracts.Models;

namespace Convention.BLL.Features.Convention.Services
{
    public interface IConventionService
    {
        Task<Guid> Create(ConventionCreateRequest request);
        Task<List<ConventionResponse>> GetActualList();
    }
}