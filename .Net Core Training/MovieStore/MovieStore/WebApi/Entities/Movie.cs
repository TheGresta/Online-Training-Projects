using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
  public class Movie
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public  DateTime PublishDate { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    public int DirectorId { get; set; }
    public Director Director { get; set; }
    public List<Actor> Actors { get; set; }
    public Actor Actor { get; set; }
  }
}