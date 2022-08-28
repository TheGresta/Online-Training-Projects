using System.Linq;
using System;
using AutoMapper;
using WebApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Applications.BookOperations.Queries.GetBookDetail
{
  public class GetBookDetailQuery
  {
    private readonly IBookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int BookId { get; set; }
    public GetBookDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public BookDetailViewModel Handle()
    {
      var book = _dbContext.Books.Include(x => x.Genre).Include(x => x.Author).Where(book => book.Id == BookId).SingleOrDefault();
      if(book is null)
        throw new InvalidOperationException("Book Could Not Be Found");
      BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
      return vm;
    }

    public class BookDetailViewModel
    {
      public string Title { get; set; }
      public string Genre { get; set; }
      public string Author { get; set; }
      public int PageCount { get; set; }
      public string PublishDate { get; set; }      
    }
  }
}