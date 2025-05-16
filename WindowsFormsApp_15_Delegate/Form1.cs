using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_15_Delegate
{
    public partial class Form1 : Form
    {
        #region # 델리케이트
        public delegate void MyDelegate();
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
        public void SayGoodbye()
        {
            Console.WriteLine("Goodbye");
        }

        public delegate void NotifyDelegate();

        public void SoundAlarm()
        {
            Console.WriteLine("1. Alarm!");
        }
        public void FlashLight()
        {
            Console.WriteLine("2. Flashing Light!");
        }
        public void SendNotification()
        {
            Console.WriteLine("3. 관리자에게 알람을 보냄!");
        }
        #endregion

        #region # 익명 메소드
        public delegate void ActionDelegate();


        #endregion

        #region # 람다식
        //함수 자체를 값 처럼 전달
        public delegate void CalcDelegate(int a, int b);
        #endregion
        public Form1()
        {
            InitializeComponent();

            MyDelegate myDelegate = new MyDelegate(SayHello);
            myDelegate();
            MyDelegate del2 = SayGoodbye;
            del2();

            Console.WriteLine("===============멀티케스트 델리게이트=================");
            NotifyDelegate nd = SoundAlarm;
            nd += FlashLight;
            nd += SendNotification;
            nd();
            nd -= FlashLight;
            nd();

            Console.WriteLine("==================익명 메서드========================");
            ActionDelegate ad = delegate ()
            {
                Console.WriteLine("람다 + 델리게이트");
            };
            ad();
            Console.WriteLine("==================내장 델리케이트====================");
            // Func, Action, Predicate

            Console.WriteLine("=====================Func<>=========================");
            Func<int, int, int> addDel = delegate (int a, int b)
            {//2개의 정수를 받고 정수를 반환하는 델리게이트
                return a + b;
            };
            int result = addDel(3, 4);
            Console.WriteLine($"{result}");
            Console.WriteLine("====================Action==========================");
            Action<string> actionDel = delegate (string str)
            {
                Console.WriteLine($"Action : {str}");
            };
            actionDel("Hello, Action");

            Console.WriteLine("====================Predicate========================");
            Predicate<int> isEven = delegate (int number)
            {
                return number % 2 == 0;
            };
            Console.WriteLine(isEven(4));

            Console.WriteLine("========================람다식===========================");
            CalcDelegate printSum = (a, b) =>
            {
                Console.WriteLine($"람다식 : {a + b}");
            };
            printSum(3, 4);

            Func<int, int, int> multiply = (a, b) => a * b;
            Console.WriteLine(multiply(3, 4));

            Console.WriteLine("=========================void 반환 람다============================");
            Action<string> callName = name => Console.WriteLine($"{name}님 환영합니다.");

            Console.WriteLine("========================bool 반환 람다===========================");
            Predicate<int> isOdd = (number) => number % 2 != 0;
            Console.WriteLine(isOdd(4));

        }
    }
}
