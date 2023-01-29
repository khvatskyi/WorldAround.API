using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Domain.Models.Base;
using WorldAround.Domain.Models.Paging;
using WorldAround.Domain.Models.Users;

namespace WorldAround.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Exists(string login)
        {
            var exists = await _usersService.Exists(login);

            return Ok(exists);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetDataParams @params, [FromQuery] GetPageModel page)
        {
            return Ok(await _usersService.GetUsersAsync(@params, page));
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUser([FromQuery] GetUserParams @params)
        {
            var user = await _usersService.GetAsync(@params);

            return Ok(user);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _usersService.GetAsync(id);

            return user != null ? Ok(user) : NotFound();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CheckPassword([FromQuery] int userId, [FromQuery] string password)
        {
            return Ok(await _usersService.CheckPassword(userId, password));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserModel user)
        {
            return Ok(await _usersService.UpdateAsync(user));
        }

        [HttpPut("[action]/{id:int}")]
        public async Task<IActionResult> UpdateImage(int id, [FromForm] IFormFile image)
        {
            return Ok(await _usersService.UpdateUserImageAsync(id, image));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdateUserPasswordParameters @params)
        {
            await _usersService.UpdatePasswordAsync(@params);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(int userId, string role)
        {
            return Ok(await _usersService.AddToRoleAsync(userId, role));
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFromRole(int userId, string role)
        {
            return Ok(await _usersService.AddToRoleAsync(userId, role));
        }
    }
}
