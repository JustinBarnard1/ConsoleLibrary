using System;
using System.Threading;
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

        }

        private void Read()
        {

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

        }
    }
}