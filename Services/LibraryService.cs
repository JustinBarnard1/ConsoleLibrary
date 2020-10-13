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
            var books = Books.FindAll(b => b.IsAvailable == available);
            if (books.Count == 0)
            {
                return "No Books Available";
            }
            string list = available ? "Books to Checkout\n" : "Books to Return\n";
            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                list += $"{i + 1}. {book.Title} - by: {book.Author}\n";
            }
            return list;
        }

        internal void Add(Book newBook)
        {
            Books.Add(newBook);
        }

        internal string Checkout(int selection)
        {
            var books = Books.FindAll(b => b.IsAvailable);
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
            var books = Books.FindAll(b => !b.IsAvailable);
            if (selection <= books.Count)
            {
                books[selection].IsAvailable = true;
                return "Successfully returned";
            }
            return "Invalid Input, please provide a number listed";
        }



        internal int FindIndexByTitle(string title)
        {
            int index = Books.FindIndex(b => b.Title == title);
            return index;
        }

        internal void Remove(int index)
        {
            Books.RemoveAt(index);
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
    }
}