using BlazorComponents.Client.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BlazorComponents.Client.Components
{
    [Authorize]
    public class AuthComponentBase : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            if (AuthService is not null)
            {
                IsAuthenticated = await AuthService.IsAuthenticated();
                //User = await AuthService.GetUser();
                Username = User?.UserName;
            }

            await base.OnInitializedAsync();
        }

        public bool IsAuthenticated { get; private set; }

        public IdentityUser? User { get; private set; }

        public string? Username { get; private set; }

        [Inject]
        protected IAuthService? AuthService { get; set; }
    }
}
