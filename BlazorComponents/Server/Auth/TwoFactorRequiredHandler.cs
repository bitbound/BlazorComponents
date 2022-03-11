using BlazorComponents.Shared.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BlazorComponents.Server.Auth
{
    public class TwoFactorRequiredHandler : AuthorizationHandler<TwoFactorRequirement>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _appConfig;

        public TwoFactorRequiredHandler(UserManager<IdentityUser> userManager, IConfiguration appConfig)
        {
            _userManager = userManager;
            _appConfig = appConfig;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, TwoFactorRequirement requirement)
        {
            
            if (context?.User?.Identity?.IsAuthenticated == true &&
                _appConfig.GetValue("Require2FA", false))
            {
                var user = await _userManager.GetUserAsync(context.User);
                if (!user.TwoFactorEnabled)
                {
                    context.Fail();
                    return;
                }
            }
            context?.Succeed(requirement);
        }
    }
}
