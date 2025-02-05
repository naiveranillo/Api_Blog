using Api_Blog.DTOs.Comment;
using Api_Blog.DTOs.Post;
using Api_Blog.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_Blog.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CommentController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Post([FromBody] CreateCommentDTO createComment)
        {
            var comment = mapper.Map<Comment>(createComment);
            context.Add(comment);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
