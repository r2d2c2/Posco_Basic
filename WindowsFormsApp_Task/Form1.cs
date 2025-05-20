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

namespace WindowsFormsApp_Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //int result = Task.Run(testInt).Result; //비동기 메서드 호출
            //Console.WriteLine($"result : {result}");
        }
        async Task<int> Test2(int a,int b)
        {
            return a + b;
        }
        async Task<int> testInt()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000); //1초 대기
                Console.WriteLine(i);
            }
            return 10; //반환값
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "작업 시작";
            await Task.Run(() => LongWork());
            label1.Text = "작업 완료";
        }
        private void LongWork()
        {
            Thread.Sleep(3000); //3초 대기
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            label1.Text="4초 대기";
            await Task.Delay(4000); //4초 대기
            label1.Text = "4초 대기 완료";
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            Task<int> task=Task.FromResult(123);
            //FromResult는 즉시 123 반환하는 Task를 생성합니다.
            int result=await task; //await로 비동기 처리
            label1.Text = $"결과 : {result}"; //결과 출력
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "모든 작업 시작";
            Task t1=Task.Run(()=>Thread.Sleep(2000)); //2초 대기
            Task t2 = Task.Run(() => Task.Delay(3000)); //3초 대기

            await Task.WhenAll(t1, t2); //모든 작업 완료 대기
            //가장 오래 걸린 작업이 완료될 때까지 대기합니다.
            label1.Text = "모든 작업 완료";
        }
    }
}
