using System;

namespace WebApi.Entities
{
  public class Order
  {
    public int Id { get; set; }
    public int BuyerId { get; set; }
    public User User { get; set; }
    public string MovieName { get; set; }
    public int MoviePrice { get; set; }
    public int MovieGenreId { get; set; }
    public Genre Genre { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    public DateTime BuyDate  { get; set; }   
  }
}