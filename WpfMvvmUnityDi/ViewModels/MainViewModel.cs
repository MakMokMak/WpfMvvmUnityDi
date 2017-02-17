using System;
using System.Collections.Generic;
using System.Windows.Input;

using MakCraft.ViewModels;
using WpfMvvmUnityDi.Models;
using WpfMvvmUnityDi.Services;

namespace WpfMvvmUnityDi.ViewModels
{
    class MainViewModel : ModalViewModelBase
    {
        public MainViewModel(IBookService bookService)
        {
            System.Diagnostics.Trace.WriteLine("MainViewModel instance: Create!");

            _bookService = bookService;
        }

        private IBookService _bookService;

        private IEnumerable<Book> _books;
        public IEnumerable<Book> Books
        {
            get { return _books; }
            set { base.SetProperty(ref _books, value); }
        }

        private object _modalKick;
        // モーダルダイアログの表示のキック用
        public object ModalKick
        {
            get { return _modalKick; }
            set { base.SetProperty(ref _modalKick, value); }
        }

        private void showInputWindowExecute()
        {
            base.DialogType = typeof(InputWindow);
            base.CommunicationDialog = null;
            base.DialogActionCallback = dialogResult =>
            {
                if (dialogResult.HasValue && dialogResult.Value)
                {
                    Books = _bookService.GetAllBooks();
                }
            };
            ModalKick = new object();
        }
        private ICommand _showInputWindowCommand;
        public ICommand ShowInputWindowCommand
        {
            get
            {
                if (_showInputWindowCommand == null)
                {
                    _showInputWindowCommand = new RelayCommand(showInputWindowExecute);
                }

                return _showInputWindowCommand;
            }
        }

        private void gcExecute()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        private ICommand _gcCommand;
        public ICommand GcCommand
        {
            get
            {
                if (_gcCommand == null)
                {
                    _gcCommand = new RelayCommand(gcExecute);
                }
                return _gcCommand;
            }
        }

        protected override void Dispose(bool disposing)
        {
            System.Diagnostics.Trace.WriteLine("MainViewModel instance: Dispose!");

            (_bookService as IDisposable)?.Dispose();

            base.Dispose(disposing);
        }
    }
}
