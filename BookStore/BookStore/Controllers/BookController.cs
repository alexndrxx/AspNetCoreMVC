using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        private readonly BookRepository _repository = null;

        public BookController(BookRepository bookRepository)
        {
            _repository = bookRepository;
        }

        [Route("all-books", Name = "allBooksRoute")]
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _repository.GetAllBooks();
            Title = "All books | BookStore";
            return View(data);
        }

        [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id, string bookName)
        {
            var data = await _repository.GetBookById(id);
            Title = "Book "+data.Title+" | BookStore";
            return View(data);
        }

        //public List<BookModel> SearchBooks(string bookName, string authorName)
        //{
        //    return _repository.SearchBooks(bookName, authorName);
        //}

        //[Route("adding-book", Name = "AddNewBookRoute")]
        public ViewResult AddNewBook(bool IsSuccess = false, int bookId = 0)
        {
            Title = "Adding book | BookStore";
            ViewBag.IsSuccess = IsSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            int id = await _repository.AddNewBook(bookModel);
            
            if(id > 0)
            {
                return RedirectToAction("AddNewBook","Book", new { IsSuccess = true, bookId = id }) ;
            }

            return View();
        }
    }
}
