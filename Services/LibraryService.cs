using System;
using System.Collections.Generic;
using Library.Models;

namespace Library.Services
{
    class LibraryService
    {
        List<Book> Books = new List<Book>();

        public string GetBooks(bool available)
        {
            string list = "";
            for (int i = 0; i < Books.Count; i++)
            {
                var book = Books[i];
                if (book.IsAvailable == available)
                {
                    list += $"{i + 1}. {book.Title} - by: {book.Author}\n";
                }
            }
            return list;
        }

        public LibraryService()
        {
            Books = new List<Book>(){
                new Book("Fake Book 1", "Fake Author 1", "Fake Desc 1"),
                new Book("Fake Book 2", "Fake Author 2", "Fake Desc 2"),
                new Book("Fake Book 3", "Fake Author 3", "Fake Desc 3"),
                new Book("Fake Book 4", "Fake Author 4", "Fake Desc 4"),
            };
        }

        internal string Checkout(int selection)
        {
            var books = Books.FindAll(b => b.IsAvailable == true);
            if (books.Count == 0)
            {
                return "No Books Available";
            }
            if (selection <= books.Count)
            {
                books[selection].IsAvailable = false;
                return "Enjoy your book";
            }
            return "Invalid Input, please provide a number listed";
        }

        internal string Return(int selection)
        {
            var books = Books.FindAll(b => b.IsAvailable == false);
            if (selection <= books.Count)
            {
                books[selection].IsAvailable = true;
                return "Successfully returned";
            }
            return "Invalid Input, please provide a number listed";
        }
    }
}