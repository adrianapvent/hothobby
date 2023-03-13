#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace hothobby.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Hobby> Hobbys { get; set; }

}