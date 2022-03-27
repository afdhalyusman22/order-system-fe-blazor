using order_system_fe_blazor.Models.Authentication;

namespace order_system_fe_blazor.Interfaces;

public interface IAuthServices
{
    Task Login(LoginRequest loginRequest);
    Task Register(RegisterRequest registerRequest);
    Task Logout();
    Task<string> CurrentUserInfo();
}