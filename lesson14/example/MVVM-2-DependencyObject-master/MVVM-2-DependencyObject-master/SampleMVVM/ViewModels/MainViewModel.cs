using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using SampleMVVM.Models;
using System.Text.Json;
using System.IO;
using System.Text;

namespace SampleMVVM.ViewModels
{
    class MainViewModel 
    {
        public ObservableCollection<BookViewModel> BooksList { get; set; }

        public MainViewModel(List<Book> books)
        {
            BooksList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b, this)));
            LoadFromFile("books.txt");
        }
        public void AddBook(Book newBook) {
            BooksList.Add(new BookViewModel(newBook, this));
        }


        public void SaveToFile(string filePath) {
            var books = BooksList.Select(b => new Book(b.Title, b.Author, b.Count)).ToList();

            string json = JsonSerializer.Serialize(books, new JsonSerializerOptions { 
                WriteIndented = true, 
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping 
            });
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }
        public void LoadFromFile(string filePath) {
            if (!File.Exists(filePath)) { return; }

            string json = File.ReadAllText(filePath);
            var books = JsonSerializer.Deserialize<List<Book>>(json);

            if (books != null) {
                BooksList.Clear();
                
                foreach (var book in books) {
                    BooksList.Add(new BookViewModel(book, this));
                }
            }
        }
    }
}
