using System;
using System.Threading;
using Library.Models;
using Library.Services;

namespace Library.Controllers
{
    class LibraryController
    {
        private LibraryService _Service { get; set; } = new LibraryService();
        private bool _running { get; set; } = true;

        public void Run()
        {
            while (_running)
            {
                GetUserInput();
            }
        }

        private void GetUserInput()
        {
            Console.WriteLine("Options:\nAdd, Info, Checkout, return, Delete, Quit \nWhat would you like to do:");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "add":
                    Add();
                    break;
                case "info":
                    Read();
                    break;
                case "checkout":
                    Checkout();
                    break;
                case "return":
                    Return();
                    break;
                case "delete":
                    Delete();
                    break;
                case "quit":
                    _running = false;
                    break;
                default:
                    Console.WriteLine("Invalid Command");
                    break;
            }
        }
        private void Add()
        {
            Console.WriteLine("What is the Title of the Book you wish to add?");
            string title = Console.ReadLine();
            Console.WriteLine("Who is the Author of the Book you wish to add?");
            string author = Console.ReadLine();
            Console.WriteLine("What is the Description of the Book you wish to add?");
            string description = Console.ReadLine();
            Book newBook = new Book(title, author, description);
            _Service.Add(newBook);
            Console.WriteLine($"You've successfully added {title} to the library");
        }

        private void Read()
        {
            Console.WriteLine(_Service.GetBooks(true));
            Console.Write("Enter the nuber of the book to get description:");
            string inputStr = Console.ReadLine();
            if (int.TryParse(inputStr, out int index) && index > 0)
            {
                Console.WriteLine(_Service.Read(index - 1));
            }
        }

        private void Checkout()
        {
            Console.WriteLine(_Service.GetBooks(true));
            Console.Write("Enter the number of the book to checkout:");
            string inputStr = Console.ReadLine();
            if (int.TryParse(inputStr, out int index) && index > 0)
            {
                Console.WriteLine(_Service.Checkout(index - 1));
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        private void Return()
        {
            Console.WriteLine(_Service.GetBooks(false));
            Console.Write("Enter the number of the book to return:");
            string inputStr = Console.ReadLine();
            if (int.TryParse(inputStr, out int index) && index > 0)
            {
                Console.WriteLine(_Service.Return(index - 1));
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        private void Delete()
        {
            Console.Write("Which Book would you like to delete: ");
            string title = Console.ReadLine().ToLower();
            int index = _Service.FindIndexByTitle(title);
            if (index == -1)
            {
                Console.WriteLine("Book does not exist in Library");
                return;
            }
            Console.WriteLine("Type 'confirm' to remove book");
            string confirm = Console.ReadLine().ToLower();
            if (confirm != "confirm")
            {
                Console.WriteLine("Invalid input, cannot delete book");
                return;
            }
            _Service.Remove(index);
            Console.WriteLine("Successfully removed Book");
        }
    }
}