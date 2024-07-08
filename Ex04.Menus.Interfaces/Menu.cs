using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class Menu : IMenu
    {
        private readonly string r_Title;
        private readonly List<IMenuItem> r_Items = new List<IMenuItem>();
        private readonly bool r_IsMainMenu;

        public string Title { get => r_Title; }

        public Menu(string i_Title, bool i_IsMainMenu = false)
        {
            r_Title = i_Title;
            r_IsMainMenu = i_IsMainMenu;
        }

        public void AddItem(IMenuItem i_Item)
        {
            r_Items.Add(i_Item);
        }

        public void Show()
        {
            while (true)
            {
                displayMenu();
                int choice = getValidChoice();

                if (choice == 0)
                {
                    break;
                }

                r_Items[choice - 1].Execute();
            }
        }

        private void displayMenu()
        {
            Console.Clear();
            Console.WriteLine(buildMenuString());
        }

        private string buildMenuString()
        {
            StringBuilder menuBuilder = new StringBuilder();

            menuBuilder.AppendLine($"--{Title}--");
            for (int i = 0; i < r_Items.Count; i++)
            {
                menuBuilder.AppendLine($"{i + 1}. {r_Items[i].Title}");
            }

            menuBuilder.AppendLine(r_IsMainMenu ? "0. Exit" : "0. Back");
            menuBuilder.Append($"Enter your request (1-{r_Items.Count} or press '0' to {(r_IsMainMenu ? "Exit" : "Back")}): ");

            return menuBuilder.ToString();
        }

        private int getValidChoice()
        {
            while (true)
            {
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out int choice);

                if (isNumber)
                {
                    if (choice >= 0 && choice <= r_Items.Count)
                    {
                        return choice;
                    }
                    Console.WriteLine("Invalid choice. Please try again.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }    

        public void Execute()
        {
            Show();
        }
    }
}
