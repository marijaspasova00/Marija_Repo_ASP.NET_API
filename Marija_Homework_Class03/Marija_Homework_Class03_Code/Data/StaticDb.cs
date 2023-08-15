using Marija_Homework_Class03_Code.Domain.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Marija_Homework_Class03_Code.Data
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book { Id = 1, Author = "J.K. Rowling", Title = "Harry Potter and the Sorcerer's Stone" },
            new Book { Id = 2, Author = "George Orwell", Title = "1984" },
            new Book { Id = 3, Author = "J.R.R. Tolkien", Title = "The Lord of the Rings" },
            new Book { Id = 4, Author = "Harper Lee", Title = "To Kill a Mockingbird" },
            new Book { Id = 5, Author = "F. Scott Fitzgerald", Title = "The Great Gatsby" },
            new Book { Id = 6, Author = "Mark Twain", Title = "Adventures of Huckleberry Finn" },
            new Book { Id = 7, Author = "Jane Austen", Title = "Pride and Prejudice" },
            new Book { Id = 8, Author = "Leo Tolstoy", Title = "War and Peace" },
            new Book { Id = 9, Author = "Gabriel García Márquez", Title = "One Hundred Years of Solitude" },
            new Book { Id = 10, Author = "Ray Bradbury", Title = "Fahrenheit 451" }
        };
    }
}
