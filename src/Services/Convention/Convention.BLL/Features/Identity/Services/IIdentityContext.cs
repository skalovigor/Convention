using Convention.Domain.Identity;

namespace Convention.BLL.Features.Identity.Services
{
    public interface IIdentityContext
    {
        IUserIdentity User { get; }
    }
}