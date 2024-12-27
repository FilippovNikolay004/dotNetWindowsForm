using SampleMVVM.Models;
using SampleMVVM.Commands;
using System.Windows.Input;
using System.Windows;
using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.Generic;
using SampleMVVM.Views;

namespace SampleMVVM.ViewModels
{
    class BookViewModel : DependencyObject
    {
        private static readonly DependencyProperty TitleProperty;
        private static readonly DependencyProperty AuthorProperty;
        private static readonly DependencyProperty CountProperty;

        private static readonly DependencyProperty NewTitleProperty;
        private static readonly DependencyProperty NewAuthorProperty;

        private MainViewModel _mainViewModel;

        static BookViewModel()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(BookViewModel));
            AuthorProperty = DependencyProperty.Register("Author", typeof(string), typeof(BookViewModel));
            CountProperty = DependencyProperty.Register("Count", typeof(int), typeof(BookViewModel));

            NewTitleProperty = DependencyProperty.Register("NewTitle", typeof(string), typeof(BookViewModel));
            NewAuthorProperty = DependencyProperty.Register("NewAuthor", typeof(string), typeof(BookViewModel));
        }

        public BookViewModel(Book book, MainViewModel mainViewModel) {
            Title = book.Title;
            Author = book.Author;
            Count = book.Count;

            _mainViewModel = mainViewModel;
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string Author
        {
            get { return (string)GetValue(AuthorProperty); }
            set { SetValue(AuthorProperty, value); }
        }

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        private DelegateCommand getItemCommand;

        public ICommand GetItemCommand
        {
            get
            {
                if (getItemCommand == null)
                {
                    getItemCommand = new DelegateCommand(param => this.GetItem(), null);
                }
                return getItemCommand;
            }
        }

        private void GetItem()
        {
            Count++;
        }


        private DelegateCommand giveItemCommand;

        public ICommand GiveItemCommand
        {
            get
            {
                if (giveItemCommand == null)
                {
                    giveItemCommand = new DelegateCommand(param => GiveItem(), param => CanGiveItem());
                }
                return giveItemCommand;
            }
        }

        private void GiveItem()
        {
            Count--;
        }

        private bool CanGiveItem()
        {
            return Count > 0;
        }


        private DelegateCommand addItemCommand;
        public ICommand AddItemCommand {
            get {
                if (addItemCommand == null) {
                    addItemCommand = new DelegateCommand(param => AddItem(), null);
                }
                return addItemCommand;
            }
        }
        private void AddItem() {
            string newTitle = (string)GetValue(NewTitleProperty);
            string newAuthor = (string)GetValue(NewAuthorProperty);

            if (newTitle == null || newAuthor == null) {
                return;
            }

            // Добавляем книгу в коллекцию через MainViewModel
            _mainViewModel.AddBook(new Book(newTitle, newAuthor, 0));

            // Очищаем поля после добавления
            SetValue(NewTitleProperty, string.Empty);
            SetValue(NewAuthorProperty, string.Empty);

            _mainViewModel.SaveToFile("books.txt");
        }
    }
}