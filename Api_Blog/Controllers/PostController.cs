using Api_Blog.DTOs.Post;
using Api_Blog.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Blog.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class PostController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PostController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreatePostDTO createPost)
        {
            var post = mapper.Map<Post>(createPost);
            context.Add(post);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{postId}")]
        public  async Task<ActionResult<GetIdPostDTO>> GetId(int postId)
        {
            var post = await context.Posts
            .Where(p => p.Id == postId)
            .Select(p => new GetIdPostDTO
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                DateOfCreation = p.DateOfCreation,
                User = new UserDto
                {
                    Id = p.User.Id,
                    Name = p.User.Name,
                    LastName = p.User.LastName,
                    Email = p.User.Email,
                    Password = p.User.Password
                },
                Category = new CategoryDto
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                }
            })
            .FirstOrDefaultAsync();

            return Ok(post);
        }

    }
}
