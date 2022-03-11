using BlazorComponents.Shared.Auth;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;

namespace BlazorComponents.Client.Auth
{
    public class TwoFactorRequiredHandler : AuthorizationHandler<TwoFactorRequirement>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TwoFactorRequirement requirement)
        {
            if (context?.User?.Identity?.IsAuthenticated == true)
            {
                // Implement a way to check if two-factor is enabled for the user,
                // such as via API call.
                //if (IsTwoFactorenabled())
                //{
                //    context.Fail();
                //    return;
                //}
            }

            context?.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
