using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using order_system_fe_blazor.Models.Authentication;
using order_system_fe_blazor.Interfaces;

namespace order_system_fe_blazor.Helpers;

public class CustomStateProvider : AuthenticationStateProvider
{
    private readonly IAuthServices api;
    private string _currentUser { get; set; }
    public CustomStateProvider(IAuthServices api)
    {
        this.api = api;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();
        try
        {
            Console.WriteLine("get current user");
            var userInfo = await GetCurrentUser();
            Console.WriteLine("currentUser" + userInfo);
            if (!string.IsNullOrEmpty(_currentUser))
            {
                var claims = new[] { new Claim(ClaimTypes.Name, userInfo) };

                Console.WriteLine("claims" + claims);
                identity = new ClaimsIdentity(claims, "Server authentication");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Request failed:" + ex.ToString());
        }
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }
    private async Task<string> GetCurrentUser()
    {
        if (!string.IsNullOrEmpty(_currentUser)) return _currentUser;
        _currentUser = await api.CurrentUserInfo();
        return _currentUser;
    }
    public async Task Logout()
    {
        await api.Logout();
        //_currentUser = null;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    public async Task Login(LoginRequest loginParameters)
    {
        await api.Login(loginParameters);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    public async Task Register(RegisterRequest registerParameters)
    {
        await api.Register(registerParameters);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}