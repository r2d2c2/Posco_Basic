using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal partial class User
    {

        public User()
        {
            money = 10000;
        }
        ~User()
        {
            Console.WriteLine("돈 지불 끝");
        }
    }
}
