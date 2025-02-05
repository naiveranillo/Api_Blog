namespace Api_Blog.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public HashSet<Comment> Comments { get; set; } = new HashSet<Comment>();
        public HashSet<Like> Likes { get; set; } = new HashSet<Like>();
        public HashSet<Favorite> Favorites { get; set; } = new HashSet<Favorite>();
    }
}
