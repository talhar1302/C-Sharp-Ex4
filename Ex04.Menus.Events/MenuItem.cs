using System;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        public string Title { get; }
        private readonly Action _action;

        public MenuItem(string title, Action action)
        {
            Title = title;
            _action = action;
        }

        public void Execute()
        {
            _action?.Invoke();
        }
    }
}
