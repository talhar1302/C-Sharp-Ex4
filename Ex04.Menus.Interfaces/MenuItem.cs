using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenuItem
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
            _action.Invoke();
        }
    }      
}
