using System.Collections.Generic;

namespace Convention.Domain.Identity
{
    public interface IUserIdentity
    {
        List<RoleType> Roles { get; set; }
        List<PermissionScope> Scopes { get; set; }
        bool IsAdmin { get; }
        bool Has(RoleType role);
        bool Has(PermissionScope scope);
        string Id { get; }
    }
    
    
}