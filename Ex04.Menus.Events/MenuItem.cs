using System;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        
        private readonly string r_Title;
        private readonly Action r_Action;

        public string Title { get=> r_Title; }

        public MenuItem(string i_Title, Action i_Action)
        {
            r_Title = i_Title;
            r_Action = i_Action;
        }

        public void Execute()
        {
            r_Action?.Invoke();
        }
    }
}
