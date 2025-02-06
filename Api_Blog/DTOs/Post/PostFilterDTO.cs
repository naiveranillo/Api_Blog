namespace Api_Blog.DTOs.Post
{
    public class PostFilterDTO
    {
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
