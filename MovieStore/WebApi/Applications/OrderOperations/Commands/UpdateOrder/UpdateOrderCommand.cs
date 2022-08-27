using System.Linq;
using System;
using WebApi.DBOperations;

namespace WebApi.Applications.OrderOperations.Commands.UpdateOrder
{
  public class UpdateOrderCommand
  {
    private readonly IMovieStoreDbContext _context;
    public int OrderId { get; set; }
    public UpdateMovieModel Model { get; set; }
    public UpdateOrderCommand(IMovieStoreDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var order = _context.Orders.SingleOrDefault(x=> x.Id == OrderId);

      if(order is null)
        throw new InvalidOperationException("Order Does Not Exist!");

      order.BuyerId = Model.BuyerId != default ? Model.BuyerId : order.BuyerId;
      order.MovieId = Model.MovieId != default ? Model.MovieId : order.MovieId;
      _context.SaveChanges();
    }

    public class UpdateMovieModel
    {
      public int MovieId { get; set; }
      public int BuyerId { get; set; }
    }
  }
}