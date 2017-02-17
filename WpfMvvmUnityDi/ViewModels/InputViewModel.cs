using System;
using System.Windows.Input;

using MakCraft.ViewModels;
using WpfMvvmUnityDi.Models;
using WpfMvvmUnityDi.Services;

namespace WpfMvvmUnityDi.ViewModels
{
    class InputViewModel : ModalViewModelBase
    {
        public InputViewModel(IBookService bookService)
        {
            System.Diagnostics.Trace.WriteLine("InputViewModel instance: Create!");

            _bookService = bookService;
        }

        private IBookService _bookService;

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

        private void addBookExecute()
        {
            var book = new Book { Title = Title, Author = Author };
            _bookService.AddBook(book);
            base.Result = true;
        }
        private ICommand _addBookCommand;
        public ICommand AddBookCommand
        {
            get
            {
                if (_addBookCommand == null)
                {
                    _addBookCommand = new RelayCommand(addBookExecute);
                }
                return _addBookCommand;
            }
        }

        protected override void Dispose(bool disposing)
        {
            System.Diagnostics.Trace.WriteLine("InputViewModel instance: Dispose!");

            (_bookService as IDisposable)?.Dispose();

            base.Dispose(disposing);
        }
    }
}
