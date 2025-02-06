using Api_Blog.DTOs.User;
using Api_Blog.Entities;
using Api_Blog.Helper;
using Api_Blog.Models;
using Api_Blog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Blog.Controllers
{
    [ApiController]
    [Route("api/access")]
    public class AccessController: Controller
    {
        private readonly ApplicationDbContext context;
        private readonly JwtService jwtService;

        public AccessController(ApplicationDbContext context
            , JwtService jwtService)
        {
            this.context = context;
            this.jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDTO createUserDto)
        {
            var email = context.Users.FirstOrDefault(u => u.Email.ToLower() == createUserDto.Email.ToLower());

            if (email != null)
               return BadRequest("El email ya está registrado.");

            var newUser = new User
            {
                Name = createUserDto.Name,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                Password = PasswordHelper.HashPassword(createUserDto.Password)
            };

            context.Users.Add(newUser);
            await context.SaveChangesAsync();

            return Ok("Usuario registrado con éxito.");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel request)
        {
            var result = await jwtService.Authenticate(request);
            if(result is null)
                return Unauthorized();

            return result;
        }

    }
}
