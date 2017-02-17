using System.Collections.Generic;

using WpfMvvmUnityDi.Models;

namespace WpfMvvmUnityDi.Services
{
    public interface IBookService
    {
        Book GetBookById(int id);

        IEnumerable<Book> GetAllBooks();

        void AddBook(Book book);
    }
}
