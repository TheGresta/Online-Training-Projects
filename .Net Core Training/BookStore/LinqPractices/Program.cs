using System;
using System.Linq;
using LinqPractices.DbOperators;

namespace LinqPractices
{
  class Program
  {
    static void Main(string[] args)
    {
      DataGenerator.Initialize();
      LinqDbContext _context = new LinqDbContext();
      var students = _context.Students.ToList<Student>();

      //Find()
      Console.WriteLine("***** Find *****");
      var student = _context.Students.Where(student => student.StudentId == 1).FirstOrDefault();
      student = _context.Students.Find(2);
      Console.WriteLine(student.Name);

      //FirstOrDefault()
      Console.WriteLine();
      Console.WriteLine("***** First Or Default *****");

      student = _context.Students.Where(student => student.Surname == "Arda").FirstOrDefault();
      Console.WriteLine(student.Name);

      student = _context.Students.FirstOrDefault(x => x.Surname == "Arda");
      Console.WriteLine(student.Name);

      //SingleOrDefault()
      Console.WriteLine();
      Console.WriteLine("***** Single Or Default *****");

      student = _context.Students.SingleOrDefault(x => x.Name == "Deniz");
      Console.WriteLine(student.Surname);

      //ToList()
      Console.WriteLine();
      Console.WriteLine("***** ToList *****");

      var studentList = _context.Students.Where(student => student.ClassId == 2).ToList();

      Console.WriteLine(studentList.Count());

      //OrderBy()

      Console.WriteLine();
      Console.WriteLine("***** OrderBy *****");

      students = _context.Students.OrderBy(x => x.StudentId).ToList();

      foreach(var st in students)
      {
        Console.WriteLine(st.StudentId + " " + st.Name + " " + st.Surname );
      }

      //OrderByDescending()

      Console.WriteLine();
      Console.WriteLine("***** OrderByDescendingy *****");

      students = _context.Students.OrderByDescending(x => x.StudentId).ToList();

      foreach(var st in students)
      {
        Console.WriteLine(st.StudentId + " " + st.Name + " " + st.Surname );
      }

      //AnonymusObjectResult()
      Console.WriteLine();
      Console.WriteLine("***** Anonymus Object Result *****");

      var anonymusObject = _context.Students.Where(x => x.ClassId == 2).Select(x => new{
        Id = x.StudentId,
        fullName = x.Name + " " + x.Surname
      });

      foreach(var obj in anonymusObject)
      {
        Console.WriteLine(obj.Id + " - " + obj.fullName);
      }
    }
  }
}