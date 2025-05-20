using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Thread_Runing
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<Thread> threads = new List<Thread>();
        DateTime startTime;
        TimeSpan elapsedTime;
        //자동차 경주

        //거리
        const int distance = 10; //10m
        public Form1()
        {
            InitializeComponent();

            Thread thread1 = new Thread(Car); //스레드 생성
            Thread thread2 = new Thread(Car); //스레드 생성
            Thread thread3 = new Thread(Car); //스레드 생성
            Thread thread4 = new Thread(Car); //스레드 생성
            Thread thread5 = new Thread(Car); //스레드 생성


            //리스트로 스레드 관리
            threads.Add(thread1);
            threads.Add(thread2);
            threads.Add(thread3);
            threads.Add(thread4);
            threads.Add(thread5);
            //스레드 시작
            foreach (Thread thread in threads)
            {
                thread.Start(); //스레드 시작
            }
            // 모든 차량이 도착할 때까지 대기
            foreach (Thread thread in threads)
            {
                thread.Join(); //스레드가 종료될 때까지 대기
            }

        }
        //차
        private void Car()
        {
            // 초속 0.1~1초
            int speed = random.Next(1, 11); // 0.1초 ~ 1초
            for (int i = 0; i <= distance; i++)
            {
                Thread.Sleep(speed * 100); // 속도에 따라 대기
                //결승선에 도착하면 차량 이름과  시간 출력
                if (i == distance)
                {
                    elapsedTime = DateTime.Now - startTime; // 경과 시간 계산
                    if(InvokeRequired) // UI 스레드가 아닌 다른 스레드에서 실행중(true)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            textBox1.Text += $"차량 {Thread.CurrentThread.ManagedThreadId} 도착! 경과 시간: {elapsedTime.TotalSeconds}초\r\n"; //텍스트 박스에 출력
                        }));
                    }
                    else
                    {// ui 메인 스레드에서 실행중
                        textBox1.Text += $"차량 {Thread.CurrentThread.ManagedThreadId} 도착! 경과 시간: {elapsedTime.TotalSeconds}초\r\n"; //텍스트 박스에 출력
                    }
                }
            }
        }

    }
}
