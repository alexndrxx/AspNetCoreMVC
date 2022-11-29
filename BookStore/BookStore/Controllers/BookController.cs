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
        public ViewResult GetAllBooks()
        {
            var data = _repository.DataSource();
            Title = "All books | BookStore";
            return View(data);
        }

        public ViewResult GetBook(int id)
        {
            var data = _repository.GetBookById(id);
            Title = "Book "+data.Title+" | BookStore";
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _repository.SearchBooks(bookName, authorName);
        }
    }
}
