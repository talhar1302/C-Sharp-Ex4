using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test.OperationsForInterface
{
    public class ShowDate : IOperation
    {
        public void NotifyToOperate()
        {
            MenuManager.ShowDate();
        }
    }
}
