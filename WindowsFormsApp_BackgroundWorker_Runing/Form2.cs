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
    public partial class Form2 : Form
    {
        BackgroundWorker bcw=new BackgroundWorker();
        public Form2()
        {
            InitializeComponent();

            bcw.WorkerReportsProgress = true; //진행률 보고(0~100)
            progressBar1.Minimum = 0; //최소값
            progressBar1.Maximum = 100; //최대값

            bcw.DoWork += Bcw_Dowork;
            bcw.ProgressChanged += Bcw_ProgressChanged;
            bcw.RunWorkerCompleted += Bcw_RunWorkerCompleted;
        }

        private void Bcw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //작업 완료시 실행
            MessageBox.Show("완료됨");
        }

        private void Bcw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // 변경시 실행
            progressBar1.Value = e.ProgressPercentage; //진행률 업데이트 % 0~100
        }

        private void Bcw_Dowork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 101; i++)
            {
                Thread.Sleep(30);
                bcw.ReportProgress(i); //진행률 보고
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bcw.RunWorkerAsync(); //비동기 실행
        }

    }
}
