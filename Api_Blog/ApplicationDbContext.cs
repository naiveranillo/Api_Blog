using Api_Blog.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Api_Blog
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        public DbSet<Post> Posts => Set<Post>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Like> Likes => Set<Like>();
        public DbSet<Favorite> Favorites => Set<Favorite>();
    }
}
