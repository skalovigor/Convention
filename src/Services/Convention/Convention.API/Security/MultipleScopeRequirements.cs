using System;
using System.Collections.Generic;
using System.Linq;

namespace Convention.API.Security
{
    public class MultipleScopeRequirements : BaseScopeRequirement<MultipleScopeRequirements>
    {
        private readonly string[] _scopes;

        public MultipleScopeRequirements(params string[] scopes)
        {
            _scopes = scopes;
        }

        protected override bool ScopesCorrect(IEnumerable<string> scopes)
        {
            return scopes.Any(s => _scopes.Any(sc => sc.Equals(s, StringComparison.CurrentCultureIgnoreCase)));
        }
    }
}