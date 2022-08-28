using System.Linq;

namespace LinqPractices.DbOperators
{
  public class DataGenerator
  {
    public static void Initialize()
    {
      using(var context = new LinqDbContext())
      {
        if(context.Students.Any())
          return;
        
        context.Students.AddRange(
          new Student(){
            Name = "Ayse",
            Surname = "Yılmaz",
            ClassId = 1
          },

          new Student(){
            Name = "Deniz",
            Surname = "Arda",
            ClassId = 1
          },

          new Student(){
            Name = "Umut",
            Surname = "Arda",
            ClassId = 2
          },

          new Student(){
            Name = "Merve",
            Surname = "Çalışkan",
            ClassId = 2
          }
        );

        context.SaveChanges();

      }
    }
  }
}