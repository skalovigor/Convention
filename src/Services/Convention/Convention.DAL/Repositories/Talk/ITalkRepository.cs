using System;
using Convention.Common.Repository;

namespace Convention.DAL.Repositories.Talk
{
    public interface ITalkRepository: IRepository<Guid, Domain.Models.Talk>
    {
        
    }
}