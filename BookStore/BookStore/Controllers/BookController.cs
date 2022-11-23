using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        public string GetAllBooks()
        {
            return "All books";
        }

        public string GetBook(int id)
        {
            return $"book id = {id}";
        }

        public string SearchBooks(string bookName, string authorName)
        {
            return $"book with name = {bookName} & author = {authorName}";
        }
    }
}
