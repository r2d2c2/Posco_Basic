using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Square
    {
        //속성 변의 길이
        //메소드 넓이를 구하는 기능
        private int length;//변의 길이

        public int Length { 
            get { return length; }
            set
            {
                if (value < 0)
                {
                    length = 0;// 음수 방지
                }
                else
                {
                    length = value;
                }
            }
        }
        public Square()
        {
            Length = 1;
            Console.WriteLine("기본 square 객채가 만들어 젔습니다.");
        }
        public Square(int length)
        {
            Length = length;
            Console.WriteLine($"길이 {length}로 square 객체가 만들어 진다");
        }

        public int GetArea()
        {
            return length * length;
        }
    }
}
