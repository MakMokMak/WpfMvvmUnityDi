using System.Collections.Generic;

using WpfMvvmUnityDi.Models;

namespace WpfMvvmUnityDi.DAL
{
    public interface IDataLayer
    {
        Book GetBook(int id);

        IEnumerable<Book> GetBooks();

        void AddBook(Book book);

        void UpdateBook(Book book);

        void DeleteBook(int id);

        void Save();
    }
}
