using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
  public interface IPlayListDbContext
  {
    DbSet<Singer> Singers { get; set; }
    DbSet<Song> Songs { get; set; }
    DbSet<User> Users { get; set; }
    int SaveChanges();
  }
}