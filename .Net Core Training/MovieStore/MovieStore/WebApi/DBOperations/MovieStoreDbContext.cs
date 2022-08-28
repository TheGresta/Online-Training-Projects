using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
  public class MovieStoreDbContext : DbContext, IMovieStoreDbContext
  {
    public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> option):base(option)
    { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }

    public override int SaveChanges()
    {
      return base.SaveChanges();
    }
  }
}