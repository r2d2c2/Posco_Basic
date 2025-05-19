using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Event
{
    //일반 델리게이트
    public delegate void Notify();
    //이벤트 델리케이트
    public delegate void Notify2();
    public partial class Form1 : Form
    {
        static void AlarmMessage()
        {
            Console.WriteLine("알람 울림");
        }
        public event EventHandler MyEvent;// object sender, EventArgs e 포함
        // 수동으로 번튼 이벤트 생성
        private void ConsoleMessage(object sender, EventArgs e)
        {
            Console.WriteLine("이벤트 발생");
        }
        private void BtnTrigger(object sender, EventArgs e)
        {
            //MyEvent?.Invoke(this, e); //이벤트 발생
            MyEvent?.Invoke(this,EventArgs.Empty); //이벤트 발생
        }
        public Form1()
        {
            InitializeComponent();

            Alarm alarm = new Alarm();
            alarm.OnRing+=AlarmMessage;
            alarm.OnRing();

            MyEvent += ConsoleMessage;

            button1.Click += MyEvent;

            Alarm2 alarm2=new Alarm2();
            alarm2.OnRing += AlarmMessage;
            //alarm2.OnRing();//(컴파일 오류) 이벤트는 메서드처럼 호출할 수 없다.
            alarm2.Trigger(); //Trigger() 메서드를 통해 호출해야 한다.
        }

        private void Form1_MyEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public class Alarm
        {
            public Notify OnRing;
            //델리게이트 변수 선언
        }
        public class Alarm2
        {
            public event Notify2 OnRing;
            //이벤트 변수 선언

            public void Trigger()
            {
                if (OnRing!=null)
                {
                    OnRing();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //클레스 내부에서만 실행 될수 있게 버튼 사용
            //내부 코드
            // public event EventHandler MyEvent;
            // button1.MyEvent += new EventHandler(button1_Click);
            // object sender 이벤트를 발생 시킨 객체
            // EventArgs e 이벤트에 대한 데이터
        }
    }
}
