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
            //UserLogin
            string username = "";
            User user = new User();
            username = user.GetUserName();
                     
            //MainMenu
            MainMenu menu = new MainMenu(username);
            menu.Menu(username);
            
        }
    }
}
