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

namespace WindowsFormsApp_dic_Runing
{
    public partial class Form1 : Form
    {

        Dictionary<string, string> idAndPhonNumber = new Dictionary<string, string>();
        Dictionary<string,string> idAndPassword = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            string myId=string.Empty;
            string myPassword=string.Empty;
            string myPhoneNumber = null;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\김철수\\Documents\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    Stream fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        //fileContent = reader.ReadToEnd();
                        myId=reader.ReadLine();
                        myPassword = reader.ReadLine();
                        myPhoneNumber = reader.ReadLine();
                        idAndPassword.Add(myId, myPassword);
                        idAndPhonNumber.Add(myId, myPhoneNumber);
                    }
                }
            }

            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
            //textBox1.Text = myId;
            //textBox2.Text = myPassword;
            //textBox3.Text = myPhoneNumber;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=idAndPassword.Keys.ToString())
            {
                MessageBox.Show("아이디가 틀렸습니다.");
            }
            else if (textBox2.Text != idAndPassword.Values.ToString())
            {
                MessageBox.Show("비밀번호가 틀렸습니다.");
            }
            else
            {
                MessageBox.Show("로그인 성공");
            }
        }
    }
}
