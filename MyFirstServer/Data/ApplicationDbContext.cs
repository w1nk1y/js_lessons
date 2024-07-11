using Microsoft.EntityFrameworkCore;
using MyFirstServer.Data.Models;
namespace MyFirstServer.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = "Andrey"
        };

        modelBuilder.Entity<User>().HasData(user);

        modelBuilder.Entity<Post>().HasData(

            new Post
            {
                body = "123456",
                title = "098765432",
                userId = user.Id
            }
        );
    }

}

