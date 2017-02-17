using System;
using System.Collections.Generic;
using System.Linq;

using WpfMvvmUnityDi.Models;

namespace WpfMvvmUnityDi.DAL
{
    public class DataLayer : IDataLayer, IDisposable
    {
        public DataLayer()
        {
            System.Diagnostics.Trace.WriteLine("Datalayer instance: Create!");
        }

        public void AddBook(Book book)
        {
            var books = InMemoryBooks.Instance;
            var max = (books.Count != 0) ? books.Max(s => s.Id) : 0;
            book.Id = ++max;
            books.Add(new Book(book));
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int id)
        {
            var books = InMemoryBooks.Instance;
            return new Book(books.Find(m => m.Id == id));
        }

        public IEnumerable<Book> GetBooks()
        {
            var books = InMemoryBooks.Instance;
            return books.Select(s => new Book(s)).ToArray();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void Save() { }

        public void Dispose()
        {
            System.Diagnostics.Trace.WriteLine("Datalayer instance: Dispose!");
        }
    }

    class InMemoryBooks : List<Book>
    {
        static InMemoryBooks() { } // コンパイラによる beforefieldinit フラグの付加を抑止する
        private InMemoryBooks() { } // 外部からのインスタンス生成を抑止

        // 初回アクセス時に InMemoryBooks クラスのインスタンスを生成する(スレッドセーフ)。
        private static Lazy<InMemoryBooks> _instance = new Lazy<InMemoryBooks>(() => {
            var instance = new InMemoryBooks();
            return instance;
        });

        // InMemoryBooks のインスタンスを取得する get のみのプロパティ
        public static InMemoryBooks Instance => _instance.Value;
    }
}
