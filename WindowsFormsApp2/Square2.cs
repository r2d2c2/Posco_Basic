using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public partial class Square2
    {
        //속성 변의 길이
        //메소드 넓이를 구하는 기능
        private int length;//변의 길이

        public int Length
        {
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
    }
}
