namespace Api_Blog.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public List<Like> Likes { get; set; } = [];
        public List<Comment> Comments { get; set; } = [];
        public List<Favorite> Favorites { get; set; } = [];
    }
}
