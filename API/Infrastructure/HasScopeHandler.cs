using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure
{
    // credits to : https://www.jerriepelser.com/blog/creating-dynamic-authorization-policies-aspnet-core/
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer)) 
                return Task.CompletedTask;

            var scopes = context.User
                .FindFirst(c => c.Type == "scope" && c.Issuer == requirement.Issuer)
                .Value.Split(' ');

            if (scopes.Any(s => s == requirement.Scope)) 
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}