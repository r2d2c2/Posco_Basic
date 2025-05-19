using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Event
{
    public partial class Form3 : Form
    {
        public delegate void EveantDelegate(string message); //이벤트 델리게이트 선언
        class EventManager
        {
            event EveantDelegate MyEvent; //이벤트 선언
            int count = 0; //카운트 변수
            Dictionary<int, object> dic = new Dictionary<int, object>(); //딕셔너리 선언
            //이벤트 등록
            public void  AddEvent(EveantDelegate eventHandler) //이벤트 핸들러 등록 메서드
            {
                count++; //카운트 증가
                MyEvent += eventHandler; //이벤트 핸들러 추가
                dic.Add(count, MyEvent); //딕셔너리에 추가
            }
            //이벤트 해제
            public void RemoveEvent(EveantDelegate eventHandler) //이벤트 핸들러 해제 메서드
            {
                count--; //카운트 감소
                MyEvent -= eventHandler; //이벤트 핸들러 제거
                dic.Remove(count); //딕셔너리에서 제거
            }
            public void TriggerEvent(string message) //이벤트 발생 메서드
            {
                // 딕셔너리 안에 있는 이벤트 호출(message 검색)
                foreach (var item in dic) //딕셔너리의 모든 항목에 대해 반복
                {
                    Console.WriteLine($"이벤트 카운트 : {item.Key}, 매개변수 : {message}"); //이벤트 카운트와 매개변수 출력
                }
            }
        }
        static void Print(string message) //이벤트 핸들러 메서드
        {
            Console.WriteLine($"이벤트 발생: {message}"); //메시지 출력
        }
        public Form3()
        {
            InitializeComponent();

            EventManager eventManager = new EventManager(); //이벤트 매니저 객체 생성
            eventManager.AddEvent(Print); //이벤트 핸들러 등록
            eventManager.TriggerEvent("이벤트1"); //이벤트 발생 메서드 호출
            // 등록
            eventManager.AddEvent((message) => //람다 식으로 이벤트 핸들러 등록
            {
                Console.WriteLine($"람다식 이벤트 발생: {message}"); //메시지 출력
            });

            eventManager.RemoveEvent(Print); //이벤트 핸들러 해제
            eventManager.TriggerEvent("이벤트2"); //이벤트 발생 메서드 호출

        }
    }
}
