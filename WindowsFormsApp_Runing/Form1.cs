using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Runing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Board board = new Board();
            board.Initialize(50);

            //커서 안보이게 하기
            Console.CursorVisible = false;

            Player player = new User();
            while (true)
            {
                Console.WriteLine("모험을 시작 하시겠습니까? yes/no");
                string input=Console.ReadLine();
                if (input == "yes")
                {
                    break;
                }
                else if (input == "no")
                {
                    // 폼 종료
                    this.Close();
                    return;
                }
            }
            Word word = new Word();
            word.Lobby(ref player);
            Console.WriteLine($"당신의 직업은 {player.Job}입니다.");


            while (true)
            {
                Console.Clear();
                board.Render();
                System.Threading.Thread.Sleep(100);
            }
        }
        int InputLoop()
        {

        }
    }
}
