using BookStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id = 1, Author = "Boris", Title = "C++" },
                new BookModel() { Id = 2, Author = "Matwee", Title = "C" },
                new BookModel() { Id = 3, Author = "Misha", Title = "Java" },
                new BookModel() { Id = 4, Author = "Kolya", Title = "Pascal" },
                new BookModel() { Id = 5, Author = "Alex", Title = "C#" },
            };
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBooks(string authorName, string bookName)
        {
            return DataSource().Where( x=> x.Author == authorName || x.Title == bookName).ToList();
        }

        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
    }
}
