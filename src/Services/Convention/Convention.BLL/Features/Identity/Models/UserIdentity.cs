using System.Collections.Generic;
using Convention.Domain.Identity;

namespace Convention.BLL.Features.Identity.Models
{
    public class UserIdentity : IUserIdentity
    {
        public List<RoleType> Roles { get; set; }
        public List<PermissionScope> Scopes { get; set; }
        public bool IsAdmin => Has(RoleType.Admin);
        public bool Has(RoleType role) => Roles.Contains(role);
        public bool Has(PermissionScope scope) => Scopes.Contains(scope);
        public string Id { get; set; }
    }
}