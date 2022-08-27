using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
  public interface IBookStoreDbContext
  {
    DbSet<Singer> Singer { get; set; }
    DbSet<Song> Song { get; set; }
    DbSet<User> Users { get; set; }
    int SaveChanges();
  }
}