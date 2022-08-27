using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
  public class Song
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    public int SingerId { get; set; }
    public Singer Singer { get; set; }
    public  DateTime PublishDate { get; set; }
  }
}