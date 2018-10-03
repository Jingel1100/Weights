using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weights_v2._0
{
    class Errors
    {
        internal static bool NonValidAction()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  !** Please enter a valid character. **! ");
            Console.WriteLine();
            return true;
        }
    }
}
