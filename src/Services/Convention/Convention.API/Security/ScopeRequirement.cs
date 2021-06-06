using System;
using System.Collections.Generic;
using System.Linq;

namespace Convention.API.Security
{
    public class ScopeRequirement : BaseScopeRequirement<ScopeRequirement>
    {
        private readonly string _scope;

        public ScopeRequirement(string scope)
        {
            _scope = scope;
        }

        protected override bool ScopesCorrect(IEnumerable<string> scopes)
        {
            return scopes.Any(s => s.Equals(_scope, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}