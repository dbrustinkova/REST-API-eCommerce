using AppGr8.WebApiECommerce.DataAccess;
using AppGr8.WebApiECommerce.Services;
using AppGr8.WebApiECommerce.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppGr8.WebApiECommerce.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserService service;
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;

        public UsersController(UserService service, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            this.service = service;
            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllUsers()
        {
            var users = service.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (service.Contains(id))
            {
                var user = service.Get(id);
                return Ok(user);
            }
            else
                return NotFound($"Unable to find user with id {id}");
        }

        [HttpPost("Create")]
        public IActionResult Create(User user)
        {
            var createdUser = service.Create(user);

            return Ok(createdUser);
        }

        [HttpPut("Update")]
        public IActionResult Update(User user)
        {
            if (service.Contains(user.Id))
            {
                var updatedUser = service.Update(user);
                return Ok(updatedUser);
            }
            else
                return NotFound($"Unable to find user with id {user.Id}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (service.Contains(id))
            {
                service.Delete(id);
                return NoContent();
            }
            else
                return NotFound($"Unable to find user with id {id}");
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(User user)
        {
            if (service.UserExist(user.UserName, user.Password))
            {
                var token = jWTAuthenticationManager.GenerateToken(user);
                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}
