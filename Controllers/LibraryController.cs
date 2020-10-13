using System;

namespace Library.Controllers
{
    class LibraryController
    {
        private bool _running { get; set; }

        public void Run()
        {
            while (_running)
            {
                GetUserInput();
            }
        }

        private void GetUserInput()
        {
            Console.WriteLine("Options:\nAdd, Info, Checkout, Dropoff, Delete, Quit \nWhat would you like to do:");
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

        private void Info()
        {

        }

        private void Checkout()
        {

        }

        private void Return()
        {

        }

        private void Delete()
        {

        }
    }
}