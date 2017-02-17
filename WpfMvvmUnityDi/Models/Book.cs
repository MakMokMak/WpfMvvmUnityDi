using MakCraft.ViewModels;

namespace WpfMvvmUnityDi.Models
{
    public class Book : NotifyObject
    {
        public Book() { }
        public Book(Book book) : this(book.Id, book.Title, book.Author) { }
        public Book(int id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
        }

        public int Id { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { base.SetProperty(ref _title, value); }
        }

        private string _author;
        public string Author
        {
            get { return _author; }
            set { base.SetProperty(ref _author, value); }
        }
    }
}
