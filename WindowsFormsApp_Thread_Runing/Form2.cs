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
    public partial class Form2 : Form
    {
        int rank = 1; //순위
        int finishedCars = 0;//도착한 차량의 수
        List<Thread> threads = new List<Thread>(); //스레드 리스트
        Random random = new Random(); //랜덤 객체 생성
        string[] cars= { "차량1", "차량2", "차량3", "차량4", "차량5" }; //차량 이름 배열
        const int FINISH_LINE = 100; //결승선 위치

        static object lockObj = new object();//공유데이터 보호
        public Form2()
        {
            InitializeComponent();

            StartRace();
        }
        void StartRace()
        {
            foreach(string name in cars)
            {

                Thread t = new Thread(() => RunRace(name));
                threads.Add(t); //스레드 리스트에 추가
                t.Start(); //스레드 시작

            }
        }
        void RunRace(string car)
        {
            int distance = 0;//주행 거리
            int waitTime;//대기 시간
            //레이스 시작 시간 기록
            DateTime startTime = DateTime.Now;
            while (distance < FINISH_LINE)
            {
                lock (lockObj)
                {
                    waitTime = random.Next(100, 1000); //0.1초 ~ 1초 대기
                }
                
                distance += 10;
                Thread.Sleep(waitTime); //대기
            }
            //도착 시간
            DateTime endTime = DateTime.Now;
            TimeSpan elapsedTime = endTime - startTime; //경과 시간 계산

            lock (lockObj)
            {
                int myRank = rank++;
                Invoke((MethodInvoker)(() =>
                {
                    textBox1.Text += $"{myRank}등 : {car} 도착! 경과 시간: {elapsedTime.TotalSeconds}초\r\n"; //텍스트 박스에 출력
                }));
                finishedCars++; //도착한 차량 수 증가
                if (finishedCars == cars.Length) //모든 차량이 도착했을 때
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        textBox1.Text += $"\r\n 모든 차량이 도착했습니다! \r\n";
                    }));
                }
            }
            
        }
    }
}
