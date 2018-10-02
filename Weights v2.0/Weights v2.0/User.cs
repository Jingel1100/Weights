using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weights_v2._0
{
    class User
    {
        string username = " ";

        public User()
        {
            username = " no name passed ";
        }

        internal string GetUserName()
        {
            string username;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  Welcome to Weight Book ");
            Console.WriteLine();
            Console.Write("  Enter your username: ");
            username = Console.ReadLine();

            return username;                     
        }
    } 
}
