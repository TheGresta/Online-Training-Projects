using System.Linq;
using System;
using AutoMapper;
using WebApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApi.Applications.OrderOperations.Queries.GetOrderDetail
{
  public class GetOrderDetailQuery
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    public int OrderId { get; set; }
    public GetOrderDetailQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public OrderDetailViewModel Handle()
    {
      var order = _context.Orders.Include(x => x.Movie).Include(x => x.Genre).Include(x => x.User).SingleOrDefault(order => order.Id == OrderId);
      if(order is null)
        throw new InvalidOperationException("Order Could Not Be Found");
      OrderDetailViewModel vm = _mapper.Map<OrderDetailViewModel>(order);
      return vm;
    }

    public class OrderDetailViewModel
    {
    public string BuyerName { get; set; }
    public DateTime BuyDate  { get; set; }   
    public string MovieName { get; set; }    
    public string MovieGenre { get; set; }
    public string MoviePrice { get; set; } 
    }
  }
}