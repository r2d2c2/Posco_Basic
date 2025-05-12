using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public partial class Square2
    {
        public Square2()
        {
            Length = 1;
            Console.WriteLine("기본 square 객채가 만들어 젔습니다.");
        }
        public Square2(int length)
        {
            Length = length;
            Console.WriteLine($"길이 {length}로 square 객체가 만들어 진다");
        }
    }
}
