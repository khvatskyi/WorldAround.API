using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Domain.Entities;

namespace WorldAround.Application.Services;

public class RolesService : IRolesService
{
    private readonly RoleManager<Role> _roleManager;

    public RolesService(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<IReadOnlyCollection<Role>> GetAllRolesAsync()
    {
        return await _roleManager.Roles.ToListAsync();
    }

    public async Task CreateAsync(string name)
    {
        await _roleManager.CreateAsync(new Role { Name = name });
    }

    public async Task DeleteAsync(int roleId)
    {
        var role = await _roleManager.Roles.AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id.Equals(roleId));

        await _roleManager.DeleteAsync(role);
    }
}
