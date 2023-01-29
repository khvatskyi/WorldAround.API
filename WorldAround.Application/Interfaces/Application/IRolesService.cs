using WorldAround.Domain.Entities;

namespace WorldAround.Application.Interfaces.Application;

public interface IRolesService
{
    Task<IReadOnlyCollection<Role>> GetAllRolesAsync();

    Task CreateAsync(string name);

    Task DeleteAsync(int roleId);
}
