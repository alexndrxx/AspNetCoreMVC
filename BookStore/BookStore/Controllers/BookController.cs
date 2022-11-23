﻿using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _repository = null;

        public BookController()
        {
            _repository = new BookRepository();
        }
        public List<BookModel> GetAllBooks()
        {
            return _repository.DataSource();
        }

        public BookModel GetBook(int id)
        {
            return _repository.GetBookById(id);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _repository.SearchBooks(bookName, authorName);
        }
    }
}
