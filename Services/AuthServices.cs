using System.Net.Http.Json;
using System.Text.Json;
using order_system_fe_blazor.Models.Authentication;
using order_system_fe_blazor.Interfaces;

namespace order_system_fe_blazor.Services;

public class AuthServices : IAuthServices
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorageService;
    private string _currentUser;
    private string _userKey = "user";
    public AuthServices(HttpClient httpClient, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }
    public async Task<string> CurrentUserInfo()
    {
        _currentUser = await _localStorageService.GetItem<string>(_userKey);
        Console.WriteLine("localstorage value" + _currentUser);
        return _currentUser;
    }
    public async Task Login(LoginRequest loginRequest)
    {
        var result = await _httpClient.PostAsJsonAsync("/admin/login", loginRequest);
        Console.WriteLine(result.Content.ReadAsStringAsync());
        if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            throw new Exception("Failed Login");
        result.EnsureSuccessStatusCode();
        var desUser = JsonSerializer.Deserialize<CurrentUser>(await result.Content.ReadAsStringAsync());
        await _localStorageService.SetItem(_userKey, desUser.data.user.email);

    }
    public async Task Logout()
    {
        await _localStorageService.RemoveItem(_userKey);
    }
    public async Task Register(RegisterRequest registerRequest)
    {
        var result = await _httpClient.PostAsJsonAsync("api/auth/register", registerRequest);
        if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
        result.EnsureSuccessStatusCode();
    }
}