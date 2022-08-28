using AutoMapper;
using WebApi.Applications.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Applications.AuthorOperations.Queries.GetAuthors;
using WebApi.Applications.GenreOperations.Queries.GetGenreDetail;
using WebApi.Applications.GenreOperations.Queries.GetGenres;
using WebApi.Applications.UserOperations.Commands.CreateUser;
using WebApi.Applications.UserOperations.Queries.GetUserDetail;
using WebApi.Applications.UserOperations.Queries.GetUsers;
using WebApi.Entities;
using static WebApi.Applications.BookOperations.Commands.CreateBook.CreateBookCommand;
using static WebApi.Applications.BookOperations.Queries.GetBookDetail.GetBookDetailQuery;
using static WebApi.Applications.BookOperations.Queries.GetBooks.GetBooksQuery;

namespace WebAi.Common
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<CreateBookModel, Book>();
      CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.LastName));
      CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.LastName));
      CreateMap<Genre, GenresViewModel>();
      CreateMap<Genre, GenreDetailViewModel>();
      CreateMap<Author, AuthorsViewModel>();
      CreateMap<Author, AuthorDetailViewModel>();
      CreateMap<CreateUserModel, User>();
      CreateMap<User, UsersViewModel>();
      CreateMap<User, UserDetailViewModel>();
    }
  }
}