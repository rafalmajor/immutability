using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace linq
{
    public class LinqUnitTest
    {
        private readonly List<Book> library = new List<Book>();

        [Fact]
        public void LinqTest()
        {
            library.
            Select(b => b.Author).
            Where(a => a.Age >= 50).
            Distinct().
            Select(x => x.Surname.ToUpper()).
            Distinct().
            ToList();
        }

        [Fact]
        public void WithoutLinqTest()
        {
            var authors = new List<Author>();
            foreach(var book in library)
            {
                var author = book.Author;
                if (author.Age >= 50)
                    {
                        authors.Add(author);
                        if (authors.Count == 15)
                            break;
                    }
            }

            var result = new List<string>();
            foreach(var author in authors)
            {
                string name = author.Surname.ToUpper();
                if (!result.Contains(name))
                    result.Add(name);
            }
        }
    }

    public class Author
    {
        public string Surname { get; set; }

        public int Age { get; set; }
    }

    public class Book
    {
        public string Name { get; set; }

        public Author Author { get; set; }
    }
}
