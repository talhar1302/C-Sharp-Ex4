using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class Menu : IMenu
    {
        private readonly string r_Title;
        private readonly List<IMenuItem> r_items = new List<IMenuItem>();
        private readonly bool r_isMainMenu;

        public string Title { get=> r_Title; }

        public Menu(string i_title, bool i_isMainMenu = false)
        {
            r_Title = i_title;
            r_isMainMenu = i_isMainMenu;
        }

        public void AddItem(IMenuItem i_item)
        {
            r_items.Add(i_item);
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

                r_items[choice - 1].Execute();
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

            for (int i = 0; i < r_items.Count; i++)
            {
                menuBuilder.AppendLine($"{i + 1}. {r_items[i].Title}");
            }

            menuBuilder.AppendLine(r_isMainMenu ? "0. Exit" : "0. Back");
            menuBuilder.Append($"Enter your request (1-{r_items.Count} or press '0' to {(r_isMainMenu ? "Exit" : "Back")}): ");

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
                    if (choice >= 0 && choice <= r_items.Count)
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

        public void Execute()
        {
            Show();
        }
    }
}
