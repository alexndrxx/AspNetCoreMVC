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
                LanguageId = model.LanguageId,
                UpdatedOn = System.DateTime.UtcNow,
                CreatedOn = System.DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookPdfUrl,
            };

            newBook.bookGallery = new List<BookGallery>();
            
            foreach (var file in model.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL,
                });
            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(p => p.Id == id)
                .Select(book => new BookModel()
                {
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    TotalPages = book.TotalPages,
                    Category = book.Category,
                    CoverImageUrl = book.CoverImageUrl,
                    BookPdfUrl = book.BookPdfUrl,
                    Gallery = book.bookGallery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL,
                    }).ToList()
                }).FirstOrDefaultAsync();
        }

        //public List<BookModel> SearchBooks(string authorName, string bookName)
        //{
        //    return DataSource().Where(x => x.Author == authorName || x.Title == bookName).ToList();
        //}

        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books
                  .Select(book => new BookModel()
                  {
                      Author = book.Author,
                      Category = book.Category,
                      Description = book.Description,
                      Id = book.Id,
                      LanguageId = book.LanguageId,
                      Language = book.Language.Name,
                      Title = book.Title,
                      TotalPages = book.TotalPages,
                      CoverImageUrl = book.CoverImageUrl,
                      BookPdfUrl = book.BookPdfUrl,
                  }).ToListAsync();
        }

        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            return await _context.Books
                  .Select(book => new BookModel()
                  {
                      Author = book.Author,
                      Category = book.Category,
                      Description = book.Description,
                      Id = book.Id,
                      LanguageId = book.LanguageId,
                      Language = book.Language.Name,
                      Title = book.Title,
                      TotalPages = book.TotalPages,
                      CoverImageUrl = book.CoverImageUrl,
                      BookPdfUrl = book.BookPdfUrl,
                  }).Take(count).ToListAsync();
        }
    }
}
