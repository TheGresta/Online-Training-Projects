using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using WebApi.Entities;
using WebApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApi.Applications.OrderOperations.Queries.GetOrders
{
  public class GetOrdersQuery
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetOrdersQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public List<OrdersViewModel> Handle()
    {
      var orderList = _context.Orders.Include(x => x.Movie).Include(x => x.User).Include(x => x.Genre).OrderBy(x => x.Id).ToList<Order>();
      List<OrdersViewModel> vm = _mapper.Map<List<OrdersViewModel>>(orderList);
      return vm;
    }

    public class OrdersViewModel
    {
      public string BuyerName { get; set; }
      public DateTime BuyDate  { get; set; }   
      public string MovieName { get; set; }    
      public string MovieGenre { get; set; }
      public string MoviePrice { get; set; } 
    }
  }
}