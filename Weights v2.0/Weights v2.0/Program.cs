using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weights_v2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            //MainMenu
            MainMenu menu = new MainMenu();
            bool repeat = true;

            while (repeat == true)
            {
                // int value = index++
                // if value == 1 loop
                // menu.UserMenu();
                // repeat = menu.Menu();

                //if value is bigger than 1
                repeat = menu.Menu();
            }
            
        }
    }
}
