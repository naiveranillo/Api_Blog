using Api_Blog.DTOs.Post;
using Api_Blog.DTOs.User;
using Api_Blog.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_Blog.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UserController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateUserDTO createUser)
        {
            var post = mapper.Map<User>(createUser);
            context.Add(post);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
