using BookSystem;
using System;
using System.Collections.Generic;

Library library = new Library();

library.AddBook(new Book { Name = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Fiction", ReleaseDate = new DateTime(1951, 7, 16) });
library.AddBook(new Book { Name = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", ReleaseDate = new DateTime(1960, 7, 11) });
library.AddBook(new Book { Name = "1984", Author = "George Orwell", Genre = "Science Fiction", ReleaseDate = new DateTime(1949, 6, 8) });
library.AddBook(new Book { Name = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Fiction", ReleaseDate = new DateTime(1925, 4, 10) });
library.AddBook(new Book { Name = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance", ReleaseDate = new DateTime(1813, 1, 28) });

while (true)
{
    Console.WriteLine("1. Add a new book");
    Console.WriteLine("2. View all books");
    Console.WriteLine("3. Search for a book by title");
    Console.WriteLine("4. Sort books by release date");
    Console.WriteLine("5. Sort books by name");
    Console.WriteLine("6. Sort books by author");
    Console.WriteLine("7. Sort books by genre");
    Console.WriteLine("8. Delete books by name");
    Console.WriteLine("9. Exit");
    Console.Write("Enter your choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            try
            {
                Console.Write("Enter title: ");
                string title = Console.ReadLine();
                Console.Write("Enter author: ");
                string author = Console.ReadLine();
                Console.Write("Enter genre: ");
                string genre = Console.ReadLine();
                if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(genre))
                    throw new ArgumentNullException("Title, Author, Genre");
                Console.Write("Enter publication year (between 1 and 2100): ");
        int year;
        do
        {
            Console.Write("Enter publication year (between 1 and 2100): ");
        } while (!int.TryParse(Console.ReadLine(), out year) || year < 1 || year > 2024);

        Console.Write("Enter publication month (between 1 and 12): ");
        int month;
        do
        {
            Console.Write("Enter publication month (between 1 and 12): ");
        } while (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12);

        Console.Write("Enter publication day (between 1 and 31): ");
        int day;
        do
        {
            Console.Write("Enter publication day (between 1 and 31): ");
        } while (!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > 31);

        library.AddBook(new Book { Name = title, Author = author, Genre = genre, ReleaseDate = new DateTime(year, month, day) });
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    break;

        case "2":
            Console.WriteLine("Books in the library:");
            library.ViewBooks();
            break;
        case "3":
            Console.Write("Enter title to search: ");
            string searchTitle = Console.ReadLine();
            Book foundBook = library.SearchBook(searchTitle);
            if (foundBook != null)
            {
                Console.WriteLine(foundBook);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
            break;
        case "4":
            library.SortByReleaseDate();
            Console.WriteLine("\nBooks sorted by Release Date:");
            library.ViewBooks();
            break;
        case "5":
            library.SortByName();
            Console.WriteLine("\nBooks sorted by Name:");
            library.ViewBooks();
            break;
        case "6":
            library.SortByAuthor();
            Console.WriteLine("\nBooks sorted by Author:");
            library.ViewBooks();
            break;
        case "7":
            library.SortByGenre();
            Console.WriteLine("\nBooks sorted by Genre:");
            library.ViewBooks();
            break;
        case "8":
            Console.Write("Enter exactly book name to delete : ");
            string[] bookNamesToDelete = Console.ReadLine().Split(',');
            List<string> booksToDelete = new List<string>(bookNamesToDelete);
            library.DeleteBooksByName(booksToDelete);
            Console.WriteLine($"\nAfter deleting the specified book:");
            library.ViewBooks();
            break;
        case "9":
            return;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}
