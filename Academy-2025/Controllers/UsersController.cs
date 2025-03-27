using Academy_2025.Data;
using Academy_2025.DTOs;
using Academy_2025.Repositories;
using Academy_2025.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        // GET: api/<UsersController>
        [HttpGet]
        [Authorize(Policy = "AdminOnlyPolicy")]
        public async Task<IEnumerable<UserDTO>> GetAsync()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> GetAsync(int id)
        {
            var user = await _service.GetByIdAsync(id);

            return user == null ? NotFound() : user;
        }

        // POST api/<UsersController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> PostAsync([FromBody] UserDTO data)
        {
            await _service.CreateAsync(data);

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> PutAsync(int id, [FromBody] UserDTO data)
        {
            var user = await _service.UpdateAsync(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);

            return result ? NoContent() : NotFound();
        }

        [Route("above18")]
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetAbove18Async()
        {
            return await _service.GetUsersAbove18Async();
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> Me()
        {
            var userIdClaim = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            int userId = int.Parse(userIdClaim);

            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Unauthorized();
            }

            UserDTO user = await _service.GetByIdAsync(userId);

            return user;
        }
    }
}
