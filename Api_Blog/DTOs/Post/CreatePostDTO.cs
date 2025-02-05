namespace Api_Blog.DTOs.Post
{
    public class CreatePostDTO
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
