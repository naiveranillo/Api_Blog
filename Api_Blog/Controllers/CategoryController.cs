using Api_Blog.DTOs.Category;
using Api_Blog.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_Blog.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CategoryController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateCategoryDTO createCategory)
        {
            var category = mapper.Map<Category>(createCategory);
            context.Add(category);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
