namespace Api_Blog.DTOs.Comment
{
    public class CreateCommentDTO
    {
        public string Content { get; set; } = null!;
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
