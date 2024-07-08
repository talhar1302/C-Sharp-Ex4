using System;
using Ex04.Menus.Interfaces;
using Ex04.Menus.Events;
using Ex04.Menus.Test.OperationsForInterface;

namespace Ex04.Menus.Test
{
    public class MenuManager
    {
        public static void RunInterfaceMenu()
        {
            Interfaces.IMenu mainMenu = new Interfaces.Menu("Delegates Main Menu", true);

            Interfaces.IMenu versionMenu = new Interfaces.Menu("Version and Capitals");
            versionMenu.AddItem(new Interfaces.MenuItem("Show Version", new ShowVersion()));
            versionMenu.AddItem(new Interfaces.MenuItem("Count Capitals", new CountCapitals()));

            Interfaces.IMenu dateTimeMenu = new Interfaces.Menu("Show Date/Time");
            dateTimeMenu.AddItem(new Interfaces.MenuItem("Show Time", new ShowTime()));
            dateTimeMenu.AddItem(new Interfaces.MenuItem("Show Date", new ShowDate()));

            mainMenu.AddItem(versionMenu);
            mainMenu.AddItem(dateTimeMenu);

            mainMenu.Show();
        }

        public static void RunEventMenu()
        {
            Events.Menu mainMenu = new Events.Menu("Events Main Menu", true);

            Events.Menu versionMenu = new Events.Menu("Version and Capitals");
            versionMenu.AddItem(new Events.MenuItem("Show Version", ShowVersion));
            versionMenu.AddItem(new Events.MenuItem("Count Capitals", CountCapitals));

            Events.Menu dateTimeMenu = new Events.Menu("Show Date/Time");
            dateTimeMenu.AddItem(new Events.MenuItem("Show Time", ShowTime));
            dateTimeMenu.AddItem(new Events.MenuItem("Show Date", ShowDate));

            mainMenu.AddItem(new Events.MenuItem(versionMenu.Title, versionMenu.Show));
            mainMenu.AddItem(new Events.MenuItem(dateTimeMenu.Title, dateTimeMenu.Show));

            mainMenu.Show();
        }

        private static void continueWithAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
        public static void ShowVersion()
        {
            Console.WriteLine("App Version: 24.2.4.9504");
            continueWithAnyKey();
        }

        public static void CountCapitals()
        {
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();
            int count = 0;
            foreach (char c in sentence)
            {
                if (char.IsUpper(c)) count++;
            }
            Console.WriteLine($"There are {count} capital letters in your sentence.");
            continueWithAnyKey();
        }

        public static void ShowTime()
        {
            Console.WriteLine($"The current time is: {DateTime.Now.ToShortTimeString()}");
            continueWithAnyKey();
        }

        public static void ShowDate()
        {
            Console.WriteLine($"Today's date is: {DateTime.Today.ToShortDateString()}");
            continueWithAnyKey();
        }
    }
}
