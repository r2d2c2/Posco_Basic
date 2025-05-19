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
    public partial class Form4 : Form
    {
        public delegate void EventDelegate();
        class EventManager
        {
            private Dictionary<string, EventDelegate> eventDictionary = new Dictionary<string, EventDelegate>();
            public void RegisterEvent(string eventName,EventDelegate callback)
            {
                if (!eventDictionary.ContainsKey(eventName))// 이름이 없으면 생성
                {
                    eventDictionary[eventName]= callback;
                }
                else
                {
                    eventDictionary[eventName] += callback; //이벤트가 이미 존재하면 추가
                }
            }
            public void RemoveEvent(string eventName, EventDelegate callback)
            {
                if (eventDictionary.ContainsKey(eventName))//이벤트가 존재하면 제거
                {
                    eventDictionary[eventName] -= callback;
                    if (eventDictionary[eventName] == null)//이벤트가 없으면 제거
                    {
                        eventDictionary.Remove(eventName);//키 삭제
                    }
                }
            }
            public void InvokeEvent(string eventName)//이벤트 호출
            {
                if (eventDictionary.ContainsKey(eventName))//이벤트가 존재하면 호출
                {
                    eventDictionary[eventName]?.Invoke();
                    //함수()
                    //함수.Invoke() //함수()와 같음
                    //함수?.Invoke() //null이면 호출 안함
                }
            }
        }
        public Form4()
        {
            InitializeComponent();

            EventManager eventManager = new EventManager();
            //이벤트 추가
            eventManager.RegisterEvent("click", OnButtonClick);
            eventManager.RegisterEvent("click", TextClick);
            //이벤트 호출
            eventManager.InvokeEvent("click");
            //이벤트 제거
            eventManager.RemoveEvent("click", TextClick); 
            //이벤트 호출
            eventManager.InvokeEvent("click"); //TextClick()만 호출됨
        }
        // 메서드 1
        public void OnButtonClick()
        {
            Console.WriteLine("버튼 클릭 이벤트 발생");
        }
        // 메서드 2
        public void TextClick()
        {
            Console.WriteLine("텍스트 클릭 이벤트 발생");
        }
    }
}
