using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAi.Common;
using WebApi.DBOperations;

namespace TestSetup
{
  public class CommonTestFixture
  {
    public MovieStoreDbContext Context { get; set; }
    public IMapper Mapper { get; set; }
    public CommonTestFixture()
    {
      var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName:"MovieStoreTestDB").Options;
      Context = new MovieStoreDbContext(options);
      Context.Database.EnsureCreated();
      Context.AddActors();
      Context.AddDirectors();
      Context.AddGenres();
      Context.AddMovies();
      Context.AddUsers();
      Context.SaveChanges();

      Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
    }
  }
}