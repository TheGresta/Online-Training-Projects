using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
  public static class Authors
  {
    public static void AddAuthors(this BookStoreDbContext context)
    {
      context.Authors.AddRange(
          new Author{Name = "Eric", LastName = "Ries", BirthDate = DateTime.ParseExact("1978-09-22", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)},
          new Author{Name = "Charlotte", LastName = "Gilman", BirthDate = DateTime.ParseExact("1860-07-03", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)},
          new Author{ Name = "Frank", LastName = "Herbert", BirthDate = DateTime.ParseExact("1920-10-08", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)});
    }
  }
}