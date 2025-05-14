using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Try_Runing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string name=null;
            try
            {
                Console.Write("닉네임을 입력하세요");
                name = Console.ReadLine();
                if(string.IsNullOrEmpty(name))
                {
                    throw new Exception("닉네임을 입력하세요");
                }
                else if (name.Length < 2)
                {
                    throw new Exception("닉네임은 2자 이상 입려하세요");
                }
                else if (name.Contains("admin"))
                {
                    throw new Exception("닉네임에 'admin'은 포함할 수 없습니다.");
                }
                Console.WriteLine("닉네임이 등록 되어 습니다");
                Console.WriteLine($"{name}님 환영합니다.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("프로그램을 종료 합니다.");
            }

        }
    }
}
