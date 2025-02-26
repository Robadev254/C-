using System;
using System.Collections.Generic;

// Define the Book class
class Book
{
    public string Author { get; set; }
    public double Price { get; set; }
    public string Title { get; set; }
    public int BookNumber { get; set; }
    public int CopiesAvailable { get; set; }

    // Constructor to initialize book details
    public Book(string author, double price, string title, int bookNumber, int copiesAvailable)
    {
        Author = author;
        Price = price;
        Title = title;
        BookNumber = bookNumber;
        CopiesAvailable = copiesAvailable;
    }

    // Display book details
    public void Display()
    {
        Console.WriteLine($"Book Number: {BookNumber}, Title: {Title}, Author: {Author}, Price: ${Price}, Copies Available: {CopiesAvailable}");
    }
}

// Library class to manage book inventory
class Library
{
    private List<Book> books = new List<Book>();

    // Method to add a new book to the database
    public void AddBook()
    {
        Console.Write("Enter Author: ");
        string author = Console.ReadLine();

        Console.Write("Enter Price: ");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Book Number: ");
        int bookNumber = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Number of Copies: ");
        int copiesAvailable = Convert.ToInt32(Console.ReadLine());

        books.Add(new Book(author, price, title, bookNumber, copiesAvailable));
        Console.WriteLine("Book added successfully!\n");
    }

    // Method to display all books in the database
    public void DisplayBooks()
    {
        Console.WriteLine("\nList of Books in the Library:");
        if (books.Count == 0)
        {
            Console.WriteLine("No books available in the database.");
            return;
        }

        foreach (var book in books)
        {
            book.Display();
        }
    }
}

// Main program to test the functionality
class Program
{
    static void Main()
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add New Book");
            Console.WriteLine("2. Display Books");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input, please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    library.AddBook();
                    break;
                case 2:
                    library.DisplayBooks();
                    break;
                case 3:
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}

