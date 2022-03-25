using System.ComponentModel.DataAnnotations;

namespace order_system_fe_blazor.Models.Authentication;

public class RegisterRequest
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
    public string PasswordConfirm { get; set; }
}

public class LoginRequest
{
    [Required]
    public string email { get; set; }
    [Required]
    public string password { get; set; }
}

// public class CurrentUser
// {
//     public bool IsAuthenticated { get; set; }
//     public string UserName { get; set; }
//     public Dictionary<string, string> Claims { get; set; }
// }

public class User
{
    public string email { get; set; }
}

public class Data
{
    public string token { get; set; }
    public User user { get; set; }
}

public class CurrentUser
{
    public Data data { get; set; }
}