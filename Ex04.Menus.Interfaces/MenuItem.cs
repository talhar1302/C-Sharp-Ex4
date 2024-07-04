using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenuItem
    {
        private readonly string r_Title;
        private readonly IOperation r_operation;

        public string Title { get=> r_Title; }

        public MenuItem(string i_title, IOperation i_operation)
        {
            r_Title = i_title;
            r_operation = i_operation;
        }

        public void Execute()
        {
            r_operation.NotifyToOperate();
        }
    }      
}
