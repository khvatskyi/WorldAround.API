using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WorldAround.Application.Helpers;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Domain.Entities;
using WorldAround.Domain.Models.Identity;

namespace WorldAround.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IMapper _mapper;
    private readonly IJwtTokenHelper _tokenHelper;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthenticationService(
        IMapper mapper
        , IJwtTokenHelper tokenHelper
        , UserManager<User> userManager
        , SignInManager<User> signInManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenHelper = tokenHelper;
    }

    public async Task<AuthenticationResultModel> AuthenticateAsync(LoginModel loginModel)
    {
        var login = loginModel.Login;
        var user = UserHelper.IsEmail(login) ?
                await _userManager.FindByEmailAsync(login)
                : await _userManager.FindByNameAsync(login);

        if (user == null)
        {
            return new AuthenticationResultModel
            {
                Details = new SignInResult()
            };
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);

        if (!result.Succeeded)
        {
            return new AuthenticationResultModel
            {
                Details = result
            };
        }

        var roles = await _userManager.GetRolesAsync(user);

        return new AuthenticationResultModel
        {
            Details = result,
            Token = _tokenHelper.GenerateJwtAccessToken(user, roles),
        };
    }

    public async Task<IdentityResult> CreateAsync(RegistrationModel registrationModel)
    {
        var user = _mapper.Map<User>(registrationModel);

        var result = await _userManager.CreateAsync(user, registrationModel.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
        }

        return result;
    }
}
