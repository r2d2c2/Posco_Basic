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

namespace WindowsFormsApp_BackgroundWorker_Runing
{
    public partial class Form1 : Form
    {
        BackgroundWorker worker;
        public Form1()
        {
            InitializeComponent();

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true; //진행률 보고(0~100)
            worker.DoWork += Worker_DoWork; //작업 실행
            worker.ProgressChanged += Worker_ProgressChanged; //진행률 보고
            worker.RunWorkerCompleted += Worker_Completed; //작업 완료
        }

        private void Worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("완료됨");
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage; //진행률 업데이트 % 0~100
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 101; i++)
            {
                Thread.Sleep(30);
                worker.ReportProgress(i); //진행률 보고
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!worker.IsBusy) //작업 중이 아닐 때만 실행
            {
                progressBar1.Value = 0; //진행률 초기화
                worker.RunWorkerAsync(); //비동기 실행
            }
        }
    }
}
