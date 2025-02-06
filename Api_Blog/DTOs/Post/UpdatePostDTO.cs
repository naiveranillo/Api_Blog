namespace Api_Blog.DTOs.Post
{
    public class UpdatePostDTO
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
