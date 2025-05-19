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
    public delegate void EventDelegate(Dictionary<object,object> dic);
    public partial class Form2 : Form
    {
        public class EventManager
        {
            public event EventDelegate MyEvent; //이벤트 선언
            public void TriggerEvent(Dictionary<object, object> dic) //이벤트 발생 메서드
            {
                MyEvent?.Invoke(dic); //이벤트가 null이 아닐 때만 호출
            }
        }

        static void Print(Dictionary<object, object> dic)//invoke 메서드에서 호출되는 메서드
        {
            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        public Form2()
        {
            InitializeComponent();

            Dictionary<object, object> dic = new Dictionary<object, object>();
            dic.Add("이름", "홍길동");


            EventManager eventManager = new EventManager();
            eventManager.MyEvent += Print; //이벤트 핸들러 등록
            eventManager.TriggerEvent(dic); //이벤트 발생 // 이름 : 홍길동
            eventManager.MyEvent -=Print;
            //람다 식으로 
            eventManager.MyEvent += (d) =>// 메서드 등록
            {
                d.Add("김철수", "김철수철수");
                foreach (var item in d)
                {
                    Console.WriteLine($"람다 : {item.Key}: {item.Value}");
                }
            };
            dic.Add("name","name2");
            eventManager.TriggerEvent(dic); //이벤트 발생 메서드 바로 실행 
            //람다 : 이름 : 홍길동 //람다 : name : name2 //람다 : 김철수 : 김철수철수
        }
    }
}
