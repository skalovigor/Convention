using Convention.Domain.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Convention.API.Attributes
{
    public class AuthorizeRole : AuthorizeAttribute
    {
        public AuthorizeRole(params RoleType[] roles)
        {
            Roles = string.Join(",", roles);
        }
    }
}