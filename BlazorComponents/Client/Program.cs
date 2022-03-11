using BlazorComponents.Client;
using BlazorComponents.Client.Auth;
using BlazorComponents.Client.Services;
using BlazorComponents.Shared.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddHttpClient("BlazorComponents.ServerAPI", client => 
        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(serviceProvider => 
    serviceProvider.
        GetRequiredService<IHttpClientFactory>().
        CreateClient("BlazorComponents.ServerAPI"));

builder.Services.AddApiAuthorization();
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy(TwoFactorRequirement.PolicyName, builder =>
    {
        builder.Requirements.Add(new TwoFactorRequirement());
    });
});

builder.Services.AddSingleton<IJsInterop, JsInterop>();
builder.Services.AddSingleton<IModalService, ModalService>();
builder.Services.AddSingleton<IToastService, ToastService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthorizationHandler, TwoFactorRequiredHandler>();

await builder.Build().RunAsync();
