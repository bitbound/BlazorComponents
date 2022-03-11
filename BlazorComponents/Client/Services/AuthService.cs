using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BlazorComponents.Client.Services
{
    public interface IAuthService
    {
        Task<bool> IsAuthenticated();
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
            var state = await _authProvider.GetAuthenticationStateAsync();
            return state?.User?.Identity?.IsAuthenticated ?? false;
        }
    }
}
