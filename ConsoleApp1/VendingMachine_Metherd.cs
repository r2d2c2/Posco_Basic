using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal partial class VendingMachine
    {
        public int Dispense(int i)
        {
            if (price > i)
            {
                Console.WriteLine("돈 부족");
                return i;
            }
            else
            {
                Console.WriteLine($"음료 투하 잔얙 : {i - price}");
                return i - price;
            }
        }
    }
}
