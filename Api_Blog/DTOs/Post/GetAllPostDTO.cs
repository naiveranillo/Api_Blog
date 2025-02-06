namespace Api_Blog.DTOs.Post
{
    public class GetAllPostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime DateOfCreation { get; set; }
        public UserDto User { get; set; } = null!;
        public CategoryDto Category { get; set; } = null!;
        public int Likes { get; set; }
    }
}
