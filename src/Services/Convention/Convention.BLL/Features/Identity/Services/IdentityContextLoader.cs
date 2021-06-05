using System;
using System.Linq;
using System.Security.Claims;
using Convention.BLL.Features.Identity.Models;
using Convention.BLL.Infrastructure.Helpers;
using Convention.Domain.Identity;
using Microsoft.AspNetCore.Http;

namespace Convention.BLL.Features.Identity.Services
{
    public class IdentityContextLoader : IIdentityContext
    {
        private readonly HttpContext _httpContext;
        private IUserIdentity _userIdentity;
        public IUserIdentity User => _userIdentity ??= Load();

        public IdentityContextLoader(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor.HttpContext));;
        }
        
        private IUserIdentity Load()
        {
            var userIdentity = new UserIdentity();
            var claims = _httpContext.User.Claims;

            userIdentity.Id = _httpContext.User.Identity?.Name;
            userIdentity.Scopes = EnumHelper.GetEnumDescription<PermissionScope>(claims
                .FirstOrDefault(m=> m.Type == "scope")?.Value
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList());
            userIdentity.Roles = EnumHelper.GetEnumDescription<RoleType>(claims
                .FirstOrDefault(m=> m.Type.EndsWith(ClaimTypes.Role))?.Value
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList());
                
            return userIdentity;
        }
    }
}