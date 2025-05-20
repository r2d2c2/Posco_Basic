using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Task_Runing
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog == null || string.IsNullOrEmpty(openFileDialog.FileName))
            {
                MessageBox.Show("먼저 파일을 선택하세요.");
                return;
            }
            await ReadFileAsync(openFileDialog.FileName); //비동기 메서드 호출
        }
        private async Task ReadFileAsync(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = await reader.ReadToEndAsync(); //비동기 파일 읽기
                textBox1.Text = content; //읽은 내용 출력
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 파일 탐색기 대화상자 열기
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*"; //파일 형식 필터
            openFileDialog.Title = "파일 선택"; //대화상자 제목
            openFileDialog.InitialDirectory = "\"C:\\Users\\김철수\\Documents\\"; //초기 디렉토리
            // 탐색기 창 열기
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 선택한 파일 경로 출력
                textBox1.Text = openFileDialog.FileName;
            }
        }
    }
}
