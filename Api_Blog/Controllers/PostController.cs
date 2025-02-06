using Api_Blog.DTOs.Like;
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

        [HttpPost("add")]
        public async Task<ActionResult> Post([FromBody] CreatePostDTO createPost)
        {
            var post = mapper.Map<Post>(createPost);
            context.Add(post);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("add-like/{postId}")]
        public async Task<ActionResult> PostAddLike(int postId, [FromQuery] LikeCreateDto like)
        {
            // aqui tomas el usuario logeado y tomas su id
            var newLike = new Like
            {
                UserId = like.UserId,
                PostId = postId
            };

            var post = await context.Posts.Include(p => p.Likes).FirstOrDefaultAsync(p => p.Id == postId);

            if (post == null)
                return NotFound();

            if (post.Likes.Any(l => l.UserId == like.UserId))
                return BadRequest("El usuario ya ha dado like a este post.");

            //post.Likes.Add(newLike);

            context.Likes.Add(newLike);

            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{postId}")]
        public async Task<ActionResult<GetIdPostDTO>> GetId(int postId)
        {
            var post = await context.Posts.Include(p => p.Likes)
                .Include(p => p.User).Include(p => p.Category).Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(p => p.Id == postId);

            if (post == null)
                return NotFound();


            var postResponse = mapper.Map<GetIdPostDTO>(post);
            postResponse.Likes = post.Likes.Count;

            return Ok(postResponse);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdatePostDTO updatePost)
        {
            var post = await context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (post == null)
                return NotFound();

            post.Title = updatePost.Title;
            post.Content = updatePost.Content;
            post.CategoryId = updatePost.CategoryId;

            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("get-posts")]
        public async Task<ActionResult<List<GetAllPostDTO>>> GetPosts([FromQuery] PostFilterDTO filters)
        {
            var query = context.Posts
        .Include(p => p.User)
        .Include(p => p.Category)
        .Include(p => p.Likes)
        .AsQueryable(); 

            if (filters.CategoryId.HasValue)
            {
                query = query.Where(p => p.Category.Id == filters.CategoryId.Value);
            }

            if (filters.UserId.HasValue)
            {
                query = query.Where(p => p.User.Id == filters.UserId.Value);
            }

            var totalRecords = await query.CountAsync();

            var posts = await query
                .OrderByDescending(p => p.DateOfCreation)
                .Skip((filters.PageNumber - 1) * filters.PageSize)
                .Take(filters.PageSize)
                .ToListAsync();

            var postDtos = mapper.Map<List<GetAllPostDTO>>(posts);
     
            return Ok(new
            {
                TotalRecords = totalRecords,
                PageNumber = filters.PageNumber,
                PageSize = filters.PageSize,
                Data = postDtos
            });
        }
    }
}
