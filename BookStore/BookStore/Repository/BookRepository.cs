using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Title = model.Title,
                Author = model.Author,
                Category = model.Category,
                Description = model.Description,
                TotalPages = model.TotalPages,
                Language = model.Language,
                UpdatedOn = System.DateTime.UtcNow,
                CreatedOn = System.DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var findBook = await _context.Books.FirstOrDefaultAsync(p => p.Id == id);
            if (findBook != null)
                return new BookModel
                {
                    Title = findBook.Title,
                    Author = findBook.Author,
                    Description = findBook.Description,
                    Id = findBook.Id,
                    Language = findBook.Language,
                    TotalPages = findBook.TotalPages,
                    Category = findBook.Category
                };
            else
                return null;
        }

        //public List<BookModel> SearchBooks(string authorName, string bookName)
        //{
        //    return DataSource().Where(x => x.Author == authorName || x.Title == bookName).ToList();
        //}

        public async Task<List<BookModel>>  GetAllBooks()
        {
            List<BookModel> books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();

            foreach(var book in allbooks)
            {
                books.Add(new BookModel
                {
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    TotalPages = book.TotalPages,
                    Category=book.Category,
                });
            }
            return books;
        }
    }
}
