using System.ComponentModel.DataAnnotations;

namespace Api_Blog.DTOs.Category
{
    public class CreateCategoryDTO
    {
        [StringLength(maximumLength: 150)]
        public string Name { get; set; } = null!;
    }
}
