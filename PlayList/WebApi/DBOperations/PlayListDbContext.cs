using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
  public class BookStoreDbContext : DbContext, IBookStoreDbContext
  {
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> option):base(option)
    { }

    public DbSet<Singer> Singers { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<User> Users { get; set; }

    public override int SaveChanges()
    {
      return base.SaveChanges();
    }
  }
}