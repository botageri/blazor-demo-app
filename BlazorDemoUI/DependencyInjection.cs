using BlazorDemoUI.Authentication;
using BlazorDemoUI.Data;
using BlazorDemoUI.Data.SignIn;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
namespace BlazorDemoUI;

public static class DependencyInjection
{
    public static IServiceCollection AddUI(this IServiceCollection services)
    {
        //for Authentication
        services.AddAuthenticationCore();
        services.AddScoped<ProtectedSessionStorage>();
        services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
        services.AddScoped<SignInUserService>();

        return services;
    }
}
