using System.Linq;
using System;
using AutoMapper;
using WebApi.Entities;
using WebApi.DBOperations;

namespace WebApi.Applications.OrderOperations.Commands.CreateOrder
{
  public class CreateOrderCommand
  {
    public CreateOrderModel Model { get; set; }
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    public CreateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public void Handle()
    {
      var order = _context.Orders.SingleOrDefault(x => x.User.Id == Model.BuyerId && x.Movie.Id == Model.MovieId);
      
      if(order is not null)
        throw new InvalidOperationException("Order Already Exist");

      order = _mapper.Map<Order>(Model);
      order.User = _context.Users.SingleOrDefault(x => x.Id == Model.BuyerId);
      order.Movie = _context.Movies.SingleOrDefault(x => x.Id == Model.MovieId);
      order.MovieGenreId = order.Movie.GenreId;
      _context.Orders.Add(order);
      _context.SaveChanges();
    }

    public class CreateOrderModel
    {
      public int MovieId { get; set; }
      public int BuyerId { get; set; }
      public DateTime BuyDate { get; set; } = DateTime.Now.Date;
    }
  }
}