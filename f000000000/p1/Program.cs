using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using d1;

namespace p1
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                if (arg == "--gen")
                    Class1.Gen();
                else if (arg == "--sort")
                    Class1.Sort();
                else if (arg == "--view")
                    Class1.View();

            }
        }
    }
}
