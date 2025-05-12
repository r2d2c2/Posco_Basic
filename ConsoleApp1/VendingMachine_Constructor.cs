using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal partial class VendingMachine
    {
        public VendingMachine() {
            price = 10000;
        }
        ~VendingMachine()
        {
            Console.WriteLine("자판기 작동끝");
        }
    }
}
