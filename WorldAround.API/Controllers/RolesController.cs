using Microsoft.AspNetCore.Mvc;
using WorldAround.Application.Interfaces.Application;

namespace WorldAround.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _rolesService.GetAllRolesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            await _rolesService.CreateAsync(name);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _rolesService.DeleteAsync(id);
            return Ok();
        }
    }
}
