using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Convention.API.Security
{
    public abstract class BaseScopeRequirement<T> : AuthorizationHandler<T>, IAuthorizationRequirement
        where T : IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, T requirement)
        {
            var scopeValues = context.User.Claims
                .Where(c => c.Type == "scope")
                .Select(c => c.Value)
                .ToArray();

            if (!scopeValues.Any())
            {
                return Task.CompletedTask;
            }

            var scopes = scopeValues
                .SelectMany(sv => sv.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            if (ScopesCorrect(scopes))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        protected abstract bool ScopesCorrect(IEnumerable<string> scopes);
    }
}