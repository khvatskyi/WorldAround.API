using Microsoft.AspNetCore.Identity;

namespace WorldAround.Domain.Models.Identity;

public class AuthenticationResultModel
{
    public SignInResult Details { get; set; }

    public string Token { get; set; }
}
