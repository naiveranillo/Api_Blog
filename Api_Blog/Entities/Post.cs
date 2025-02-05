using System.ComponentModel.DataAnnotations;

namespace Api_Blog.Entities
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El titulo es requerido")]
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User? User { get; set; } 
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public List<Comment> Comments { get; set; } = [];
        public List<Like> Likes { get; set; } = [];
        public List<Favorite> Favorites { get; set; } = [];
    }
}
