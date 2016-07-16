using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class BookFactory
    {
        public static IEnumerable<Book> GetBooks()
        {
            var r = new Random();

            for (int i = 0; i < 50; i++)
            {
                yield return new Book
                {
                    Id = Guid.NewGuid().ToString(),
                    Author = $"Author {i}",
                    Issued = new DateTime(r.Next(1920, DateTime.Now.Year + 1), r.Next(1,13), 1),
                    Title = $"My awesome book {i}",
                    PagesCount = r.Next(1, 501)
                };
            }
        }
    }
}