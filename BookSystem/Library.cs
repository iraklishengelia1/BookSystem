using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem
{
    internal class Library
    {
         private List<Book> _books;

        public Library()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void ViewBooks()
        {
            foreach (var book in _books)
            {
                Console.WriteLine($"\n{book}");
            }
        }

        public Book SearchBook(string title)
        {
            return _books.Find(book => book.Name.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public void SortByReleaseDate()
        {
            _books.Sort((book1, book2) => book1.ReleaseDate.CompareTo(book2.ReleaseDate));
        }

        public void SortByName()
        {
            _books.Sort((book1, book2) => book1.Name.CompareTo(book2.Name));
        }

        public void SortByAuthor()
        {
            _books.Sort((book1, book2) => book1.Author.CompareTo(book2.Author));
        }

        public void SortByGenre()
        {
            _books.Sort((book1, book2) => book1.Genre.CompareTo(book2.Genre));
        }

        public void DeleteBooksByName(List<string> bookNames)
        {
            _books.RemoveAll(book => bookNames.Contains(book.Name));
        }
    }
}
