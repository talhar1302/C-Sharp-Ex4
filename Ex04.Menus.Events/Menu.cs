using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Events
{
    public class Menu
    {
        public string Title { get; }
        private readonly List<MenuItem> _items = new List<MenuItem>();
        private readonly bool _isMainMenu;

        public Menu(string title, bool isMainMenu = false)
        {
            Title = title;
            _isMainMenu = isMainMenu;
        }

        public void AddItem(MenuItem item)
        {
            _items.Add(item);
        }

        public void Show()
        {
            while (true)
            {
                DisplayMenu();
                int choice = GetValidChoice();

                if (choice == 0)
                {
                    break;
                }

                _items[choice - 1].Execute();
            }
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine(BuildMenuString());
        }

        private string BuildMenuString()
        {
            StringBuilder menuBuilder = new StringBuilder();
            menuBuilder.AppendLine($"--{Title}--");

            for (int i = 0; i < _items.Count; i++)
            {
                menuBuilder.AppendLine($"{i + 1}. {_items[i].Title}");
            }

            menuBuilder.AppendLine(_isMainMenu ? "0. Exit" : "0. Back");
            menuBuilder.Append($"Enter your request (1-{_items.Count} or press '0' to {(_isMainMenu ? "Exit" : "Back")}): ");

            return menuBuilder.ToString();
        }

        private int GetValidChoice()
        {
            while (true)
            {
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out int choice);

                if (isNumber)
                {
                    if (choice >= 0 && choice <= _items.Count)
                    {
                        return choice;
                    }
                    Console.WriteLine("Invalid choice. Please try again.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                ContinueWithAnyKey();
            }
        }

        private void ContinueWithAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true); 
        }
    }
}
