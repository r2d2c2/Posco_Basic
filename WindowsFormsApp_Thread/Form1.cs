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

namespace WindowsFormsApp_Thread
{
    public partial class Form1 : Form
    {
        static int sharedData = 0; //공유 데이터
        public object lockObject = new object(); //스레드 동기화 객체

        public Form1()
        {
            InitializeComponent();

            Thread thread1 = new Thread(UpdataData1);
            Thread thread2 = new Thread(UpdataData2);

            thread1.Start(); //스레드 시작
            thread2.Start(); //스레드 시작

        }

        private void UpdataData2()
        {
            lock(lockObject)//스레드 동기화
            {
                for (int i = 0; i < 10; i++)
                {
                    sharedData++;
                    Thread.Sleep(10); //10ms 대기
                    if (textBox1.InvokeRequired)// UI 스레드가 아닌 다른 스레드에서 실행중(true)
                    {
                        textBox1.Invoke(new MethodInvoker(() =>
                        //Invoke UI 스레드에서 실행
                        //MethodInvoker 매개변수,반환값 없는 ui 를 실행
                        {
                            textBox1.Text += $"2 : {sharedData}\r\n"; //텍스트 박스에 출력
                        }));
                    }
                    else
                    {// ui 메인 스레드에서 실행중
                        textBox1.Text += $"2 : {sharedData}\r\n"; //텍스트 박스에 출력
                    }
                }
            }
                
        }

        private void UpdataData1()
        {
            lock (lockObject)
            {
                for (int i = 0; i < 10; i++)
                {
                    sharedData++; //공유 데이터 증가
                    Thread.Sleep(10); //10ms 대기
                    if (textBox1.InvokeRequired)// UI 스레드가 아닌 다른 스레드에서 실행중(true)
                    {
                        textBox1.Invoke(new MethodInvoker(() =>
                        //Invoke UI 스레드에서 실행
                        //MethodInvoker 매개변수,반환값 없는 ui 를 실행
                        {
                            textBox1.Text += $"1 : {sharedData}\r\n"; //텍스트 박스에 출력
                        }));
                    }
                    else
                    {// ui 메인 스레드에서 실행중
                        textBox1.Text += $"1 : {sharedData}\r\n"; //텍스트 박스에 출력
                    }

                }
            }
            
        }
    }
}
