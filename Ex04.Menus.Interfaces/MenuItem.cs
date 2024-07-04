using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenuItem
    {
        public string Title { get; }
        private readonly IOperation _operation;

        public MenuItem(string title, IOperation operation)
        {
            Title = title;
            _operation = operation;
        }

        public void Execute()
        {
            _operation.NotifyToOperate();
        }
    }      
}
