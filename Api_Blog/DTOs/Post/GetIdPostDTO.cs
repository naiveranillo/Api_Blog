namespace Api_Blog.DTOs.Post
{
    public class GetIdPostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime DateOfCreation { get; set; }
        public UserDto User { get; set; } = null!;
        public CategoryDto Category { get; set; } = null!;
        public List<CommentDto> Comments { get; set; } = [];
        public int Likes { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public UserDto? User { get; set; } 
    }
}
