using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenuItem
    {
        private readonly string r_Title;
        private readonly IOperation r_Operation;

        public string Title { get=> r_Title; }

        public MenuItem(string i_Title, IOperation i_Operation)
        {
            r_Title = i_Title;
            r_Operation = i_Operation;
        }

        public void Execute()
        {
            r_Operation.NotifyToOperate();
        }
    }      
}
