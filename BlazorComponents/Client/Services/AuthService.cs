using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BlazorComponents.Client.Services
{
    public interface IAuthService
    {
        Task<bool> IsAuthenticated();
        //Task<IdentityUser> GetUser();
    }

    public class AuthService : IAuthService
    {
        private readonly AuthenticationStateProvider _authProvider;

        public AuthService(AuthenticationStateProvider authProvider)
        {
            _authProvider = authProvider;
        }

        public async Task<bool> IsAuthenticated()
        {
            var principal = await _authProvider.GetAuthenticationStateAsync();
            return principal?.User?.Identity?.IsAuthenticated ?? false;
        }
        
        //public async Task<IdentityUser> GetUser()
        //{
        //   I had an implementation for getting the user here, but it was very project-specific.
        //}
    }
}
