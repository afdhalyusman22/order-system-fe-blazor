using System.Net.Http.Json;
using System.Text.Json;
using order_system_fe_blazor.Models.Authentication;

namespace order_system_fe_blazor.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorageService;
    private string _currentUser;
    private string _userKey = "user";
    public AuthService(HttpClient httpClient, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }
    public async Task<string> CurrentUserInfo()
    {
        _currentUser = await _localStorageService.GetItem<string>(_userKey);
        Console.WriteLine("localstorage value" + _currentUser);
        //var result = await _httpClient.GetFromJsonAsync<CurrentUser>("api/auth/currentuserinfo");
        return _currentUser;
    }
    public async Task Login(LoginRequest loginRequest)
    {
        var result = await _httpClient.PostAsJsonAsync("/admin/login", loginRequest);
        if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
        result.EnsureSuccessStatusCode();
        var desUser = JsonSerializer.Deserialize<CurrentUser>(await result.Content.ReadAsStringAsync());
        Console.WriteLine("result login = " + desUser);
        await _localStorageService.SetItem(_userKey, desUser.data.user.email);

    }
    public async Task Logout()
    {
        //var result = await _httpClient.PostAsync("api/auth/logout", null);
        //result.EnsureSuccessStatusCode();
    }
    public async Task Register(RegisterRequest registerRequest)
    {
        var result = await _httpClient.PostAsJsonAsync("api/auth/register", registerRequest);
        if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
        result.EnsureSuccessStatusCode();
    }
}