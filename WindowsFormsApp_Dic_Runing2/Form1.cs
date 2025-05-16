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

namespace WindowsFormsApp_Dic_Runing2
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> idAndPassword = new Dictionary<string, string>();
        Dictionary<string, string> idAndPhonNumber = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();


        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\Users\\김철수\\Documents\\";
            openFileDialog.Filter = "텍스트 파일(*.txt)|*.txt";
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;//선택한 파일의 경로
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 3)
                        {
                            string id = parts[0];
                            string password = parts[1];
                            string phoneNumber = null;
                            if (parts.Length >=3 && !string.IsNullOrWhiteSpace(parts[2]))// 3번째 인덱스가 비어있지 않으면
                                phoneNumber = parts[2];
                            idAndPassword.Add(id, password);
                            idAndPhonNumber.Add(id, phoneNumber);
                        }
                    }
                }
                MessageBox.Show("파일 읽기 완료");
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string inputId = textBoxId.Text.Trim();// 공백 제거
            string inputPw = textBoxPw.Text.Trim();
            if(!idAndPassword.ContainsKey(inputId))
            {
                MessageBox.Show("아이디가 존재하지 않습니다.");
                return;
            }
            else if (idAndPassword[inputId] != inputPw)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
            }
            string phone = null;
            if (idAndPhonNumber.ContainsKey(inputId) && !string.IsNullOrWhiteSpace(idAndPhonNumber[inputId]))
            {
                phone = idAndPhonNumber[inputId];
            }

            if (phone!=null)
            {
                MessageBox.Show($"로그인 성공 아이디{inputId} 비밀번호{inputPw} 전화번호{phone}");
            }
            else { MessageBox.Show($"로그인 성공 아이디{inputId} 비밀번호{inputPw} 전화번호 없음"); }
        }
    }
}
