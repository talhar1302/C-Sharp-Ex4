using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class Menu : IMenu
    {
        public string Title { get; }
        private readonly List<IMenuItem> _items = new List<IMenuItem>();
        private readonly bool _isMainMenu;

        public Menu(string title, bool isMainMenu = false)
        {
            Title = title;
            _isMainMenu = isMainMenu;
        }

        public void AddItem(IMenuItem item)
        {
            _items.Add(item);
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"--{Title}--");
                for (int i = 0; i < _items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_items[i].Title}");
                }
                Console.WriteLine(_isMainMenu ? "0. Exit" : "0. Back");

                string prompt = $"Enter your request (1-{_items.Count} or press '0' to {(_isMainMenu ? "Exit" : "Back")}): ";
                Console.Write(prompt);

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    ContinueWithAnyKey();
                    continue;
                }

                if (choice < 0 || choice > _items.Count)
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    ContinueWithAnyKey();
                    continue;
                }

                if (choice == 0)
                {
                    break;
                }

                _items[choice - 1].Execute();
            }
        }

        private void ContinueWithAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void Execute()
        {
            Show();
        }
    }
}
