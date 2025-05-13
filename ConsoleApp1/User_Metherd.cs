using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal partial class User
    {
        // 돈 지출
        public void Spend()
        {
            VendingMachine vm = new VendingMachine();
            Console.WriteLine("돈 투입");
            vm.Dispense(money);

        }
    }
}
