using System;
using System.Collections.Generic;

using WpfMvvmUnityDi.DAL;
using WpfMvvmUnityDi.Models;

namespace WpfMvvmUnityDi.Services
{
    public class BookService : IBookService, IDisposable
    {
        public BookService(IDataLayer dataLayer)
        {
            System.Diagnostics.Trace.WriteLine("BookService instance: Create!");

            _dataLayer = dataLayer;
        }

        private IDataLayer _dataLayer;

        public void AddBook(Book book)
        {
            _dataLayer.AddBook(book);
            _dataLayer.Save();
        }

        public Book GetBookById(int id)
        {
            return _dataLayer.GetBook(id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _dataLayer.GetBooks();
        }

        public void Dispose()
        {
            System.Diagnostics.Trace.WriteLine("BookService instance: Dispose!");
        }
    }
}
