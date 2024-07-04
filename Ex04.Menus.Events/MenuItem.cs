using System;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        
        private readonly string r_Title;
        private readonly Action r_action;

        public string Title { get=> r_Title; }

        public MenuItem(string i_title, Action i_action)
        {
            r_Title = i_title;
            r_action = i_action;
        }

        public void Execute()
        {
            r_action?.Invoke();
        }
    }
}
