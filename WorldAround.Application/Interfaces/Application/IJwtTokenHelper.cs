using WorldAround.Domain.Entities;

namespace WorldAround.Application.Interfaces.Application;

public interface IJwtTokenHelper
{
    string GenerateJwtAccessToken(User user, IList<string> roles);
}
