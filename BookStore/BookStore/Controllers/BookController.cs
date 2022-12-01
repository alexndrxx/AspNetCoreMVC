using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        private readonly BookRepository _repository = null;

        public BookController()
        {
            _repository = new BookRepository();
        }

        [Route("all-books", Name = "allBooksRoute")]
        public ViewResult GetAllBooks()
        {
            var data = _repository.DataSource();
            Title = "All books | BookStore";
            return View(data);
        }

        [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public ViewResult GetBook(int id, string bookName)
        {
            var data = _repository.GetBookById(id);
            Title = "Book "+data.Title+" | BookStore";
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _repository.SearchBooks(bookName, authorName);
        }

        //Route("adding-book", Name = "AddNewBookRoute")]
        public ViewResult AddNewBook()
        {
            Title = "Adding book | BookStore";
            return View();
        }

        [HttpPost]
        public bool AddNewBook(BookModel bookModel)
        {
            System.Console.WriteLine("Added book");
            return true;
        }
    }
}
