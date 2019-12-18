using Microsoft.AspNetCore.Authorization;
using System;

namespace API.Infrastructure
{
    // credits to: https://www.jerriepelser.com/blog/creating-dynamic-authorization-policies-aspnet-core/
    public class HasScopeRequirement : IAuthorizationRequirement
    {
        public string Issuer { get; }
        public string Scope { get; }

        public HasScopeRequirement(string scope, string issuer)
        {
            Scope = scope ?? throw new ArgumentNullException(nameof(scope));
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        }
    }
}