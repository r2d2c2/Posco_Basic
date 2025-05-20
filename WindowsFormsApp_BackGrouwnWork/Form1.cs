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

namespace WindowsFormsApp_BackGrouwnWork
{
    public partial class Form1 : Form
    {
        BackgroundWorker worker;
        public Form1()
        {
            InitializeComponent();

            worker =new BackgroundWorker();

            //옵션 설정
            worker.WorkerReportsProgress = true; //진행률 보고(0~100)
            worker.WorkerSupportsCancellation = false;//취소 불가

            //백그라운드 실행
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_Completed;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i <= 100; i++)
            {
                Thread.Sleep(50); //50ms 대기  0.05초
                worker.ReportProgress(i); //진행률 보고
            }
        }
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage; //진행률 업데이트 % 0~100
            labelStatus.Text = $"{e.ProgressPercentage}% 완료"; //라벨 업데이트
        }
        private void Worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //progressBar1.Value = 100; //진행률 100이 되면 실행
            labelStatus.Text = "작업 완료"; //라벨 업데이트
        }
        private void buttonStart_Click(object sender, EventArgs e)//버튼
        {
            if (!worker.IsBusy)//worker 작업 중인지 실행 : true, 대기 : false
            {
                labelStatus.Text = "작업 시작";
                progressBar1.Value = 0; //진행률 초기화
                worker.RunWorkerAsync(); //비동기 실행
            }
        }
    }
}
